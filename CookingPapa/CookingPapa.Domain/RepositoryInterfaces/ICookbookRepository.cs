using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CookingPapa.Domain.Models;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface ICookbookRepository : IRepository<Cookbook>
    {
        void Delete(int id);

        Task<Cookbook> GetEager(int id);

        Task<IEnumerable<Cookbook>> GetByUserEager(int id);
    }
}
