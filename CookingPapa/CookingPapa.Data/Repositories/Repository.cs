using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CookingPapa.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id); //Use generic Set() method because generic repository has no DbSets to reference
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList(); //Use generic Set() method because generic repository has no DbSets to reference
        }
    }
}
