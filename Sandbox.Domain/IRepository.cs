﻿using System.Linq;
using FluentNHibernate.Data;

namespace Sandbox.Domain
{
    public interface IRepository<TEntity> : IQueryable<TEntity> 
        where TEntity : Entity
    {
        TEntity Get(long id);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
