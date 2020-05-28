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
    class RecipeIngredientGroupRepository : Repository<RecipeIngredientGroups>, IRecipeIngredientGroupRepository
    {
        public RecipeIngredientGroupRepository(CookingpapaContext context) : base(context)
        {

        }

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

        public async Task<RecipeIngredientGroups> GetEager(int id)
        {
            try
            {
                var rig = await db.RecipeIngredientGroups
                .Include(rec => rec.Recipe)
                .Include(ing => ing.RecipeIngredient)
                .Include(mu => mu.RecipeMeasurement)
                .Where(rig => rig.Id == id)
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

        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }
    }
}
