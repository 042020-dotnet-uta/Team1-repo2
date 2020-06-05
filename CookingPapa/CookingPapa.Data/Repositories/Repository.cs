using System.Collections.Generic;
using CookingPapa.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CookingPapa.Data.Repositories
{
    /// <summary>
    /// Generic-type repository for data access to tables in database.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Container for the DbContext used by repositories.
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Constructor for generic repository.
        /// </summary>
        /// <param name="context">The DbContext to be used by the repository.</param>
        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Adds the given entity to the repository's database.
        /// </summary>
        /// <param name="entity">The entity to be added to the database.</param>
        public async Task<TEntity> Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }
        /// <summary>
        /// Gets an entity from the database with the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to return.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        public async Task<TEntity> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id); //Use generic Set() method because generic repository has no DbSets to reference
        }

        /// <summary>
        /// Gets all entities from the repository's table.
        /// </summary>
        /// <returns>Returns an IEnumerable containing all entries from the table.</returns>
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync(); //Use generic Set() method because generic repository has no DbSets to reference
        }
    }
}
