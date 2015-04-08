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
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
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

            base.OnActionExecuted(filterContext);
        }
    }
}