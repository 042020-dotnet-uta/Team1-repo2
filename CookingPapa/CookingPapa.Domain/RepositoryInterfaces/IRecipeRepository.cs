using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        void Delete(int id);

        Task<Recipe> GetEager(int id);

        Task<IEnumerable<Recipe>> GetAllEager();

        //need search by name method
    }
}
