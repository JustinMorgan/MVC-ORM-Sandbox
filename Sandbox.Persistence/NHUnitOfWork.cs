using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Sandbox.Persistence
{
    public class NHUnitOfWork : INHUnitOfWork
    {
        public static NHUnitOfWork Current
        {
            get { return _current; }
            set { _current = value; }
        }
        [ThreadStatic]
        private static NHUnitOfWork _current;

        public ISession Session { get; private set; }

        private readonly ISessionFactory _sessionFactory;

        /// <summary>
        /// Current transaction
        /// </summary>
        private ITransaction _transaction;

        public NHUnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                Session.Close();
            }
        }

        public void Dispose()
        {
            Session.Flush();
        }
    }
}
