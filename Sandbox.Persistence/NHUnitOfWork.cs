using System;
using System.Data;
using NHibernate;
using Sandbox.Domain;

namespace Sandbox.Persistence.NHibernate
{
    public class NHUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;

        public NHUnitOfWork(ISession session)
        {
            _session = session;
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
