using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Linq;
using Sandbox.Domain;

namespace Sandbox.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ISession _session;

        public Repository(ISession session)
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

        public TEntity Get(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public void Add(TEntity entity)
        {
            _session.Save(entity);
        }

        public void Remove(TEntity entity)
        {
            _session.Delete(entity);
        }
    }
}