using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    /// <summary>
    /// Interface for the Recipe-specific repository.
    /// </summary>
    public interface IRecipeRepository : IRepository<Recipe>
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
        Task<Recipe> GetEager(int id);

        /// <summary>
        /// Fetches all entities using eager loading.
        /// </summary>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        Task<IEnumerable<Recipe>> GetAllEager();

        //need search by name method
    }
}
