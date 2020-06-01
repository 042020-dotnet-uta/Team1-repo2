using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(CookingpapaContext context) : base(context)
        {

        }
        public async Task<User> Delete(int id)
        {
            try
            {
                var user = await db.User.FindAsync(id);
                db.User.Remove(user);
                return user;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Exception caught in UserRepository.Delete(): {e}");
                return null;
            }
        }
        public CookingpapaContext db
        {
            get { return Context as CookingpapaContext; }
        }

    }
}
