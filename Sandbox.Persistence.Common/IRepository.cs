﻿using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Persistence.Common
{
    //todo: consider removing IQueryable interface and specifying methods directly
    public interface IRepository<TEntity> : IQueryable<TEntity>
    {
        TEntity Get(long id);
        IQueryable<TEntity> Query();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void AddOrUpdate(TEntity entity);
        void Remove(TEntity entity);
    }
}
