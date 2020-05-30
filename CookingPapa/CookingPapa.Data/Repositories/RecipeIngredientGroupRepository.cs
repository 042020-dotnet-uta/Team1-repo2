using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CookingPapa.Data.Repositories
{
    /// <summary>
    /// Repository for data access to the RecipeIngredientGroups database table.
    /// </summary>
    class RecipeIngredientGroupRepository : Repository<RecipeIngredientGroups>, IRecipeIngredientGroupRepository
    {
        /// <summary>
        /// Constructor for the RecipeIngredientGroups repository.
        /// </summary>
        /// <param name="context">The DbContext to be used in the repository.</param>
        public RecipeIngredientGroupRepository(CookingpapaContext context) : base(context)
        {

        }

        /// <summary>
        /// Delete the entry at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be deleted.</param>
        public async void Delete(int id)
        {
            try
            {
                var rigR = await db.RecipeIngredientGroups.FindAsync(id);
                db.RecipeIngredientGroups.Remove(rigR);
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeIngredientGroupsRepository.Delete(): {e}");
            }
        }
        public async Task<bool> DeleteAll (int recipeId)
        {
            var allIngredients = await db.RecipeIngredientGroups.Include(x => x.Recipe)
                .Where(x => x.Recipe.Id == recipeId).ToListAsync();
            db.RemoveRange(allIngredients);
            return true;
        }

        /// <summary>
        /// Eager-loads the entity at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be fetched.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        public async Task<RecipeIngredientGroups> GetEager(int? id)
        {
            try
            {
                var rig = await db.RecipeIngredientGroups
                .Include(rec => rec.Recipe).ThenInclude(x=>x.RecipeOrigin)
                .Include(rec=>rec.Recipe).ThenInclude(x=>x.User)
                .Include(ing => ing.RecipeIngredient)
                .Include(mu => mu.RecipeMeasurement)
                .Where(rig => rig.Recipe.Id == id)
                .FirstAsync();

                return rig;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeIngredientGroupsRepository.GetEager(): {e}");
                return null;
            }

        }
        public async void AddRange(List<RecipeIngredientGroups> recipeIngredientGroups)
        {
            await db.AddRangeAsync(recipeIngredientGroups);
        }

        /// <summary>
        /// Fetches all entities with the given Recipe ID.
        /// </summary>
        /// <param name="id">The Recipe ID to filter by.</param>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        public async Task<IEnumerable<RecipeIngredientGroups>> GetByRecipeEager(int id)
        {
            try
            {
                var rigs = await db.RecipeIngredientGroups
                .Include(rec => rec.Recipe)
                .Include(ing => ing.RecipeIngredient)
                .Include(mu => mu.RecipeMeasurement)
                .Where(rec => rec.Recipe.Id == id)
                .ToListAsync();

                return rigs;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeIngredientGroupsRepository.GetAllEager(): {e}");
                return null;
            }
        }

        //add search by name?

        /// <summary>
        /// Translates the DbContext from the generic repository into a more usable version in this repository.
        /// </summary>
        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }
    }
}
