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
<<<<<<< HEAD
        Task<RecipeInformationVM> GetRecipeDetail(int id);
=======

        Task<List<GetRecipesVM>> GetRecipes(string searchPattern);
        Task<GetRecipeDetailVM> GetRecipeDetail(int id);
>>>>>>> cf7be2b5848efcd2b1db3a809a91e67ce3132ce3
        Task<Recipe> PostRecipe(PostRecipeVM recipeVM);
        Task<RecipeInformationVM> PutRecipe(PostRecipeVM recipeVM);
        Task<Recipe> DeleteRecipe(int id);
        Task<InformationVM> GetInformation();
        Task<RecipeReview> PutRecipeReview(RecipeReviewVM recipeReview);
        Task<RecipeReview> PostRecipeReview(RecipeReviewVM recipeReview);
        Task<User> CreateUser(User user);
    }
}
