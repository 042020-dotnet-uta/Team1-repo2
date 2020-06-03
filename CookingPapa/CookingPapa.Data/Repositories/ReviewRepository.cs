using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.RepositoryInterfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CookingPapa.Data.Repositories
{
    /// <summary>
    /// Repository for data access to the RecipeReview table.
    /// </summary>
    class ReviewRepository : Repository<RecipeReview>, IReviewRepository
    {
        /// <summary>
        /// Constructor for the RecipeReview repository.
        /// </summary>
        /// <param name="context">The DbContext to be used in the repository.</param>
        public ReviewRepository(CookingpapaContext context) : base(context)
        {

        }

        /// <summary>
        /// Delete the entry at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be deleted.</param>
        public async Task<RecipeReview> Delete(int id)
        {
            try
            {
                var rev = await db.RecipeReviews.FindAsync(id);
                db.RecipeReviews.Remove(rev);
                return rev;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in ReviewRepository.Delete(): {e}");
                return null;
            }
        }

        /// <summary>
        /// Eager-loads the entity at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be fetched.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        public async Task<RecipeReview> GetEager(int id)
        {
            try
            {
                var rev = await db.RecipeReviews
                .Include(rec => rec.Recipe)
                .Include(user => user.User)
                .Where(rig => rig.Id == id)
                .FirstAsync();

                return rev;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in ReviewRepository.GetEager(): {e}");
                return null;
            }

        }

        /// <summary>
        /// Fetches all entities with the given Recipe ID.
        /// </summary>
        /// <param name="id">The Recipe ID to filter by.</param>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        public async Task<IEnumerable<RecipeReview>> GetByRecipeEager(int id)
        {
/*            try
            {*/
                var revs = await db.RecipeReviews
                .Include(rec => rec.Recipe)
                .Include(user => user.User)
                .Where(rec => rec.Recipe.Id == id).ToListAsync();
                
                return revs;
/*            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in ReviewRepository.GetAllEager(): {e}");
                return null;
            }*/
        }
        public async Task<IEnumerable<RecipeReview>> UpdateReviews(int recipeId, int updatedRecipeId)
        {
            var getAllReviews = await GetByRecipeEager((int)recipeId);
            var getUpdatedRecipe = db.Recipes.Include(x => x.User).FirstAsync(x => x.Id == updatedRecipeId);
            foreach (var x in getAllReviews)
            {
                x.Recipe = await getUpdatedRecipe;
            }
            db.UpdateRange(getAllReviews);
            await db.SaveChangesAsync();
            return getAllReviews;
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
