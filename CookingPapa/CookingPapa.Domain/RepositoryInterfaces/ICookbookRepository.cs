
using System.Collections.Generic;
using System.Threading.Tasks;
using CookingPapa.Domain.Models;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    /// <summary>
    /// Interface for the Cookbook-specific repository.
    /// </summary>
    public interface ICookbookRepository : IRepository<Cookbook>
    {
        /// <summary>
        /// Delete the entry at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be deleted.</param>
        void Delete(int id);

        /// <summary>
        /// Eager-loads the entity at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be fetched.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        Task<Cookbook> GetEager(int id);

        /// <summary>
        /// Fetches all entities with the given User ID.
        /// </summary>
        /// <param name="id">The User ID to filter by.</param>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        Task<IEnumerable<Cookbook>> GetByUserEager(int id);
    }
}
