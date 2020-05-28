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
    class ReviewRepository : Repository<RecipeReview>, IReviewRepository
    {
        public ReviewRepository(CookingpapaContext context) : base(context)
        {

        }

        public async void Delete(int id)
        {
            try
            {
                var rev = await db.RecipeReviews.FindAsync(id);
                db.RecipeReviews.Remove(rev);
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in ReviewRepository.Delete(): {e}");
            }
        }

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

        public async Task<IEnumerable<RecipeReview>> GetByRecipeEager(int id)
        {
            try
            {
                var revs = await db.RecipeReviews
                .Include(rec => rec.Recipe)
                .Include(user => user.User)
                .Where(rec => rec.Recipe.Id == id)
                .ToListAsync();

                return revs;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in ReviewRepository.GetAllEager(): {e}");
                return null;
            }
        }

        //add search by name?

        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }
    }
}
