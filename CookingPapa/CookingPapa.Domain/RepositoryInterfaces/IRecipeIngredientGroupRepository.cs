using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface IRecipeIngredientGroupRepository : IRepository<RecipeIngredientGroups>
    {
        void Delete(int id);
        Task<RecipeIngredientGroups> GetEager(int id);
        Task<IEnumerable<RecipeIngredientGroups>> GetByRecipeEager(int id);
    }
}
