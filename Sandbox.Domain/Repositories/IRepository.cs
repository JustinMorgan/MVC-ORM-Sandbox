using System.Linq;

namespace Sandbox.Domain.Repositories
{
    //todo: consider removing IQueryable interface and specifying methods directly
    public interface IRepository<TEntity, TId> : IQueryable<TEntity>
    {
        TEntity Get(TId id);
        IQueryable<TEntity> Query();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void AddOrUpdate(TEntity entity);
        void Remove(TEntity entity);
    }
}
