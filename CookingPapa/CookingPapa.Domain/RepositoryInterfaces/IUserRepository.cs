using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Delete(int id);
    }
}
