using System;
using System.Web.Mvc;
using Sandbox.Persistence.Common;

namespace Sandbox.Web.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();

            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);

            if (filterContext.Exception != null && !filterContext.ExceptionHandled)
            {
                _unitOfWork.Rollback();
            }
        }
    }
}