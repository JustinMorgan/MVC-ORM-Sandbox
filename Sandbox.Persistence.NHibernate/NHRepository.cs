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
        private readonly IUnitOfWork _unitOfWork;

        private ISession Session
        {
            get { return _unitOfWork.Session; }
        }

        public NHRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TEntity Get(TId id)
        {
            return Session.Get<TEntity>(id);
        }

        public IQueryable<TEntity> Query()
        {
            return Session.Query<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return Query().Where(filter);
        }

        public void Add(TEntity entity)
        {
            Session.Save(entity);
        }

        public void Update(TEntity entity)
        {
            Session.Save(entity, entity.Id);
        }

        public void AddOrUpdate(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public void Remove(TEntity entity)
        {
            Session.Delete(entity);
        }
    }
}