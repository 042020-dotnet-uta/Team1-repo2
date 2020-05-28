using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public async void Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id); //Use generic Set() method because generic repository has no DbSets to reference
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync(); //Use generic Set() method because generic repository has no DbSets to reference
        }
    }
}
