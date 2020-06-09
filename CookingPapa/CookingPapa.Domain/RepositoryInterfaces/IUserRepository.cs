using CookingPapa.Domain.Models;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Delete(int id);
    }
}
