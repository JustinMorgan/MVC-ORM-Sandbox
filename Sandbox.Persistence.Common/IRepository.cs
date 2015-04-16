using System;
using System.Linq;
using System.Linq.Expressions;
using Sandbox.Domain;

namespace Sandbox.Persistence.Common
{
    public interface IRepository<TEntity, TId>
        where TEntity : IHaveId<TId>
        where TId : struct
    {
        TEntity Get(TId id);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void AddOrUpdate(TEntity entity);
        void Remove(TEntity entity);
    }
}
