using System;
using NHibernate;

namespace Sandbox.Persistence.Common
{
    public interface IUnitOfWork : IDisposable
    {
        ISession Session { get; }
        void Commit();
        void Rollback();
    }
}
