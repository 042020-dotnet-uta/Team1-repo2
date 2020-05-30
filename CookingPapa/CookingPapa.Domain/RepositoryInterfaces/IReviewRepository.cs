using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    /// <summary>
    /// Interface for the RecipeReview-specific repository.
    /// </summary>
    public interface IReviewRepository : IRepository<RecipeReview>
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
        Task<RecipeReview> GetEager(int id);

        /// <summary>
        /// Fetches all entities with the given Recipe ID.
        /// </summary>
        /// <param name="id">The Recipe ID to filter by.</param>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        Task<List<RecipeReview>> GetByRecipeEager(int id);
    }
}
