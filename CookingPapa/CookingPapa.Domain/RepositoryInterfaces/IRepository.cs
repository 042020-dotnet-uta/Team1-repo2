
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    /// <summary>
    /// Interface for the generic repository methods.
    /// </summary>
    /// <typeparam name="TEntity">The model the given repository contains.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds an entity to the repository's database.
        /// </summary>
        /// <param name="entity">An entity of the appropriate type to be added to the database.</param>
        Task<TEntity> Add(TEntity entity);
        void Update(TEntity entity);
        /// <summary>
        /// Retrieves an entity from the database with the given ID.
        /// </summary>
        /// <param name="id">The integer ID of the object being sought.</param>
        /// <returns>Returns the entity with the requested ID.</returns>
        Task<TEntity> Get(int id);

        /// <summary>
        /// Retrieves all entities in the repository's database table.
        /// </summary>
        /// <returns>Returns an IEnumerable containing all entities from the table.</returns>
        Task<IEnumerable<TEntity>> GetAll();
    }
}
