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
    class CookbookRepository : Repository<Cookbook>, ICookbookRepository
    {
        public CookbookRepository(CookingpapaContext context) : base(context)
        {

        }

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

        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }
    }
}
