using System.Data;
using NHibernate;
using Sandbox.Persistence.Common;

namespace Sandbox.Persistence.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransaction _transaction;
        public ISession Session { get; private set; }
        
        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Auto;
            _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (_transaction.IsActive)
            {
                _transaction.Commit();
            }
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }

        public void Dispose()
        {
            if (Session.IsOpen)
            {
                Session.Close();
            }
        }
    }
}
