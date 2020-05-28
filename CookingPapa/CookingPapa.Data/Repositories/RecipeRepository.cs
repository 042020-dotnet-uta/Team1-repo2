using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Data.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(CookingpapaContext context) : base(context)
        {

        }

        public async void Delete(int id)
        {
            try
            {
                var recipeR = await db.Recipes.FindAsync(id);
                db.Recipes.Remove(recipeR);
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in RecipeRepository.Delete(): {e}");
            }
        }

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

        //add search by name

        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }
    }
}
