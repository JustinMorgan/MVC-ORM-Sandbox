using System;
using System.Web.Mvc;
using Sandbox.Persistence.Common;

namespace Sandbox.Web
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        //todo: add scope parameter
        private IUnitOfWork _unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //todo: handle units of work for child actions, potentially overlapping UoWs
            //move to base controller class?
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            _unitOfWork.BeginTransaction();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null && !filterContext.ExceptionHandled)
            {
                _unitOfWork.Rollback();
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            try
            {
                if (filterContext.Exception != null && !filterContext.ExceptionHandled)
                {
                    _unitOfWork.Rollback();
                }
                else
                {
                    _unitOfWork.Commit();
                }
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}