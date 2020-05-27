using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;

namespace CookingPapa.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repository Constructors
        IRepository<Cookbook> Cookbooks { get; }
        IRepository<Recipe> Recipes { get; }
        IRepository<RecipeIngredient> RecipeIngredients { get; }
        IRepository<RecipeIngredientGroups> RecipeIngredientGroups { get; }
        IRepository<RecipeMeasurement> RecipeMeasurements { get; }
        IRepository<RecipeOrigin> RecipeOrigins { get; }
        IRepository<RecipeReview> RecipeReviews { get; }
        IRepository<User> Users { get; }
        #endregion

        int Complete();
    }
}
