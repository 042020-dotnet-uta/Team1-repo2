using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Business
{
    public interface IBusinessL
    {
        Task<Cookbook> PostCookbook(PostCookbookVM cookbook);
        Task<List<GetCookbookVM>> GetCookbook(int id);
        Task<List<GetRecipesVM>> GetRecipes();
        Task<RecipeInformationVM> GetRecipeDetail(int id);
        Task<Recipe> PostRecipe(PostRecipeVM recipeVM);
        Task<RecipeInformationVM> PutRecipe(PostRecipeVM recipeVM);
        Task<Recipe> DeleteRecipe(int id);
        Task<InformationVM> GetInformation();
        Task<RecipeReview> PutRecipeReview(RecipeReviewVM recipeReview);
        Task<RecipeReview> PostRecipeReview(RecipeReviewVM recipeReview);
        Task<User> CreateUser(User user);
    }
}
