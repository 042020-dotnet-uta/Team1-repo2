using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System.Threading.Tasks;

namespace CookingPapa.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repository Constructors
        ICookbookRepository Cookbooks { get; }
        IRecipeRepository Recipes { get; }
        IRepository<RecipeIngredient> RecipeIngredients { get; }
        IRecipeIngredientGroupRepository RecipeIngredientGroups { get; }
        IRepository<RecipeMeasurement> RecipeMeasurements { get; }
        IRepository<RecipeOrigin> RecipeOrigins { get; }
        IReviewRepository RecipeReviews { get; }
        IRepository<User> Users { get; }
        #endregion

        Task<int> Complete();
    }
}
