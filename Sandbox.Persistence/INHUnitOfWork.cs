using NHibernate;

namespace Sandbox.Persistence
{
    public interface INHUnitOfWork : IUnitOfWork
    {
        ISession Session { get; }
    }
}