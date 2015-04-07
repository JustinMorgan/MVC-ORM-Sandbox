using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Linq;
using Sandbox.Domain;
using Sandbox.Domain.Repositories;

namespace Sandbox.Persistence.NHibernate
{
    //todo: remove NH entity constraint
    public class NHRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : IPersistable, IHaveId<TId>
        where TId : struct
    {
        protected readonly ISession _session;

        public NHRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _session.Query<TEntity>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { return _session.Query<TEntity>().Expression; }
        }

        public Type ElementType
        {
            get { return _session.Query<TEntity>().ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _session.Query<TEntity>().Provider; }
        }

        public TEntity Get(TId id)
        {
            return _session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return _session.Query<TEntity>();
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