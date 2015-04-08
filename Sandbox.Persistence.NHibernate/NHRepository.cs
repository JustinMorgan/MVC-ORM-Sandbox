using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using Sandbox.Domain;
using Sandbox.Persistence.Common;

namespace Sandbox.Persistence.NHibernate
{
    //todo: remove NH entity constraint
    public class NHRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : IPersistable, IHaveId<TId>
        where TId : struct
    {
        private readonly ISession _session;

        public NHRepository(ISession session)
        {
            _session = session;
        }

        public TEntity Get(TId id)
        {
            return _session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _session.Query<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return Query().Where(filter);
        }

        public void Add(TEntity entity)
        {
            _session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            _session.Save(entity, entity.Id);
        }

        public void AddOrUpdate(TEntity entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Remove(TEntity entity)
        {
            _session.Delete(entity);
        }
    }
}