using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System.Threading.Tasks;

namespace CookingPapa.Domain
{
    /// <summary>
    /// Interface for the Unit of Work, the bridge between business logic and data access.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Repository Constructors
        ICookbookRepository Cookbooks { get; } //Holder for Cookbook repository
        IRecipeRepository Recipes { get; } //Holder for Recipe repository
        IRepository<RecipeIngredient> RecipeIngredients { get; } //Holder for RecipeIngredient repository
        IRecipeIngredientGroupRepository RecipeIngredientGroups { get; } //Holder for RecipeIngredientGroup repository
        IRepository<RecipeMeasurement> RecipeMeasurements { get; } //Holder for RecipeMeasurement repository
        IRepository<RecipeOrigin> RecipeOrigins { get; } //Holder for RecipeOrigin repository
        IReviewRepository RecipeReviews { get; } //Holder for RecipeReview repository
        IRepository<User> Users { get; } //Holder for User repository
        #endregion

        Task<int> Complete(); //Save changes made by the Unit of Work to the database
    }
}
