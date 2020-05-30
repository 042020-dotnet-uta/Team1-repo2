using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    /// <summary>
    /// Interface for the RecipeIngredientGroup-specific repository.
    /// </summary>
    public interface IRecipeIngredientGroupRepository : IRepository<RecipeIngredientGroups>
    {
        /// <summary>
        /// Delete the entry at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be deleted.</param>
        void Delete(int id);
        Task<bool> DeleteAll(int recipeId);

        /// <summary>
        /// Eager-loads the entity at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be fetched.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        Task<RecipeIngredientGroups> GetEager(int? id);

        /// <summary>
        /// Fetches all entities with the given Recipe ID.
        /// </summary>
        /// <param name="id">The Recipe ID to filter by.</param>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        Task<IEnumerable<RecipeIngredientGroups>> GetByRecipeEager(int id);
        void AddRange(List<RecipeIngredientGroups> recipeIngredientGroups);

    }
}
