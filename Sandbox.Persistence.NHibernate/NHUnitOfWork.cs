using System.Data;
using NHibernate;
using Sandbox.Domain.Repositories;

namespace Sandbox.Persistence.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        //todo: check that injected sessions get cleaned up and disposed properly
        private readonly ISession _session;
        private readonly ISessionFactory _sessionFactory;

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _session = sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _session.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            var transaction = _session.Transaction;

            try
            {
                transaction.Commit();
            }
            finally
            {
                _session.Close();
            }
        }

        public void Rollback()
        {
            var transaction = _session.Transaction;

            try
            {
                transaction.Rollback();
            }
            finally
            {
                _session.Close();
            }
        }

        public void Dispose()
        {
            if (_session.IsOpen)
            {
                Rollback();
            }
        }
    }
}
