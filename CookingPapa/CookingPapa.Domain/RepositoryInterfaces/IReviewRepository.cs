using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface IReviewRepository : IRepository<RecipeReview>
    {
        void Delete(int id);
        Task<RecipeReview> GetEager(int id);
        Task<IEnumerable<RecipeReview>> GetByRecipeEager(int id);
    }
}
