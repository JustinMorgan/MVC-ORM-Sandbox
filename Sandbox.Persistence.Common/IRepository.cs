using System.Linq;

namespace Sandbox.Persistence.Common
{
    public interface IRepository<TEntity> : IQueryable<TEntity> 
    {
        TEntity Get(long id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
