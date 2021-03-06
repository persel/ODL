﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ODL.DataAccess.Repositories
{
    internal class Repository<TEntity, TContext> : IRepository<TEntity> where TContext : DbContext where TEntity : class
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public TEntity GetById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).AsEnumerable();
        }

        public TEntity FindSingle(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter).SingleOrDefault();
        }

        public void Add(TEntity newEntity)
        {
            context.Set<TEntity>().Add(newEntity);
            context.SaveChanges();
        }

        public void Update()
        {
            context.SaveChanges(); // Entiteter hämtade via denna DbContext uppdateras här... Ev. kan denna anropas centralt när tjänsteanropet returnerar!
        }

        public void Delete(TEntity entity)
        {
            // OBS: Troligen ska vi här sätta ett datum, status etc, och uppdatera entiteten istället för att göra en Delete i DB!
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}
