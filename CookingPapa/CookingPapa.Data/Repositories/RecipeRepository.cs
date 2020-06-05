using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CookingPapa.Data.Repositories
{
    /// <summary>
    /// Repository for data access to the Recipe table.
    /// </summary>
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        /// <summary>
        /// Constructor for the Recipe database table.
        /// </summary>
        /// <param name="context">The DbContext to be used to construct the repository.</param>
        public RecipeRepository(CookingpapaContext context) : base(context)
        {

        }

        /// <summary>
        /// Delete the entry at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be deleted.</param>
        public async Task<Recipe> Delete(int? id)
        {
            try
            {
                var recipeR = await db.Recipes.FindAsync(id);
                db.Recipes.Remove(recipeR);
                return recipeR;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeRepository.Delete(): {e}");
                return null;
            }
        }

        /// <summary>
        /// Eager-loads the entity at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be fetched.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        public async Task<Recipe> GetEager(int id)
        {
            try
            {
                var rec = await db.Recipes
                .Include(ori => ori.RecipeOrigin)
                .Include(user => user.User)
                .Where(recipe => recipe.Id == id)
                .FirstAsync();

                return rec;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeRepository.Delete(): {e}");
                return null;
            }

        }

        /// <summary>
        /// Fetches all entities using eager loading.
        /// </summary>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        public async Task<IEnumerable<Recipe>> GetAllEager()
        {
            try
            {
                var recs = await db.Recipes
                .Include(ori => ori.RecipeOrigin)
                .Include(user => user.User)
                .ToListAsync();

                return recs;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeRepository.Delete(): {e}");
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Recipe>> FindEager(Expression<Func<Recipe, bool>> predicate)
        {
            try
            {
                var recipes = await db.Recipes
                .Include(ori => ori.RecipeOrigin)
                .Include(user => user.User)
                .Where(predicate)
                .ToListAsync();

                return recipes;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeRepository.FindEager(): {e}");
                return null;
            }
        }

        //add search by name

        /// <summary>
        /// Translates the DbContext from the generic repository into a more usable version in this repository.
        /// </summary>
        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }
    }
}
