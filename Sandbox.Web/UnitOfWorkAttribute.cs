using System;
using System.Data;
using System.Web.Mvc;
using NHibernate;

namespace Sandbox.Web
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DependencyResolver.Current
                              .GetService<ISession>()
                              .BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var transaction = DependencyResolver.Current
                                                .GetService<ISession>()
                                                .Transaction;
            
            if (transaction.IsActive)
            {
                if (filterContext.Exception != null && filterContext.ExceptionHandled)
                {
                    transaction.Rollback();
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var transaction = DependencyResolver.Current.GetService<ISession>().Transaction;

            base.OnResultExecuted(filterContext);

            try
            {
                if (transaction.IsActive)
                {
                    if (filterContext.Exception != null && !filterContext.ExceptionHandled)
                    {
                        transaction.Rollback();
                    }
                    else
                    {
                        transaction.Commit();
                    }
                }
            }
            finally
            {
                transaction.Dispose();
            }
        }

        /*private static readonly ISessionFactory _sessionFactory;

        static UnitOfWorkAttribute()
        {
            _sessionFactory = PersistenceConfig.CreateSessionFactory();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            NHUnitOfWork.Current = new NHUnitOfWork(_sessionFactory);
            NHUnitOfWork.Current.BeginTransaction();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            try
            {
                NHUnitOfWork.Current.Commit();
            }
            catch (Exception)
            {
                NHUnitOfWork.Current.Rollback();
                throw;
            }
            finally
            {
                NHUnitOfWork.Current = null;
            }
        }*/
    }
}