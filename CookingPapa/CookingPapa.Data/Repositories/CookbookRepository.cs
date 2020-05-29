using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CookingPapa.Data.Repositories
{
    /// <summary>
    /// Data Access class for the Cookbook database table.
    /// </summary>
    class CookbookRepository : Repository<Cookbook>, ICookbookRepository
    {
        /// <summary>
        /// Constructor for the Cookbook Repository.
        /// </summary>
        /// <param name="context">The DbContext to be used to build the repository.</param>
        public CookbookRepository(CookingpapaContext context) : base(context)
        {

        }

        /// <summary>
        /// Deletes the entity with the given ID from the table.
        /// </summary>
        /// <param name="id">The ID of the entity to be removed.</param>
        public async void Delete(int id)
        {
            try
            {
                var cookbookR = await db.CookBook.FindAsync(id);
                db.CookBook.Remove(cookbookR);
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in CookbookRepository.Delete(): {e}");
            }
        }

        /// <summary>
        /// Eager-loads the entity at the given ID.
        /// </summary>
        /// <param name="id">The ID of the entity to be fetched.</param>
        /// <returns>Returns the entity with the given ID.</returns>
        public async Task<Cookbook> GetEager(int id)
        {
            try
            {
                var rec = await db.CookBook
                .Include(rec => rec.Recipe)
                .Include(user => user.User)
                .Where(cookbook => cookbook.Id == id)
                .FirstAsync();

                return rec;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in CookbookRepository.GetEager(): {e}");
                return null;
            }

        }

        /// <summary>
        /// Fetches all entities with the given User ID.
        /// </summary>
        /// <param name="id">The User ID to filter by.</param>
        /// <returns>Returns an IEnumerable populated with the appropriate entities.</returns>
        public async Task<IEnumerable<Cookbook>> GetByUserEager(int id)
        {
            try
            {
                var cbs = await db.CookBook
                .Include(rec => rec.Recipe)
                .Include(user => user.User)
                .Where(user => user.User.Id == id)
                .ToListAsync();

                return cbs;
            }
            catch (Exception e)
            {
                //Log exception details
                Console.WriteLine($"Exception caught in CookbookRepository.GetAllEager(): {e}");
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
