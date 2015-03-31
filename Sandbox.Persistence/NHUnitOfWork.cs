using System;
using System.Data;
using NHibernate;
using Sandbox.Domain;

namespace Sandbox.Persistence
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            var session = _sessionFactory.OpenSession();
            session.BeginTransaction(isolationLevel);
        }

        public void Rollback()
        {
            var session = _sessionFactory.GetCurrentSession();
            var transaction = session.Transaction;

            if (transaction.IsActive)
            {
                transaction.Rollback();
            }
            else 
                throw new NotImplementedException();
        }

        public void Commit()
        {
            var session = _sessionFactory.GetCurrentSession();
            var transaction = session.Transaction;

            if (transaction.IsActive)
            {
                transaction.Commit();
            }
            else
                throw new NotImplementedException();
        }

        public void Dispose()
        {
            var session = _sessionFactory.GetCurrentSession();
            var transaction = session.Transaction;
            transaction.Dispose();
        }
    }
}
