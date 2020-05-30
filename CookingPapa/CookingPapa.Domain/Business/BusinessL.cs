using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Business
{
    public class BusinessL:IBusinessL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public BusinessL(IUnitOfWork unitOfWork, ILogger<BusinessL> logger)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Saves a recipe into a user cookbook.
        /// If the recipe already exist in the cook book, the checkIfExists will return an instance of
        /// Cookbook and return null/error to the user.
        /// </summary>
        /// <param name="cookbook">includes user Id and recipe Id to save to cookbook</param>
        /// <returns></returns>
        public async Task<Cookbook> PostCookbook(PostCookbookVM cookbook)
        {
            var checkIfExists = _unitOfWork.Cookbooks.GetByUserEager(cookbook.UserId)
                             .Result.ToList().Find(x => x.Recipe.Id == cookbook.RecipeId);
            if (checkIfExists == null)
            {
                var newCookbook = new Cookbook();
                newCookbook.User = await _unitOfWork.Users.Get(cookbook.UserId);
                newCookbook.Recipe = await _unitOfWork.Recipes.GetEager(cookbook.RecipeId);
                _unitOfWork.Cookbooks.Add(newCookbook);
                await _unitOfWork.Complete();
                return newCookbook;
            }
            return null;
        }
        /// <summary>
        /// pulls list of recipe under a cookbook and organize it into an instance of GetcookbookVM
        /// to return information client needs.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public async Task<List<GetCookbookVM>> GetCookbook(int id)
        {
            //return the specific cook book with the list of recipes.
            var cookbook = _unitOfWork.Cookbooks.GetByUserEager(id).Result.ToList();
            if (cookbook != null)
            {
                List<GetCookbookVM> newCookbookList = new List<GetCookbookVM>();
                foreach (var x in cookbook)
                {
                    newCookbookList.Add(new GetCookbookVM()
                    {
                        RecipeId = x.Recipe.Id,
                        UserId = x.User.Id,
                        CookbookId = x.Id,
                        RecipeName = x.Recipe.RecipeName,
                        RecipeOrigin = x.Recipe.RecipeOrigin.RecipeOriginName,
                        RecipeCookTime = x.Recipe.RecipeCookTime
                    }
                    );
                }
                return newCookbookList;
            }
            return null;
        }
        public async Task<List<GetRecipesVM>> GetRecipes()
        {
            var recipes = await _unitOfWork.Recipes.GetAllEager();
            List<GetRecipesVM> newRecipesList = new List<GetRecipesVM>();
            foreach(var x in recipes)
            {
                newRecipesList.Add(new GetRecipesVM()
                {
                    RecipeId = x.Id,
                    UserId = x.User.Id,
                    UserName = x.User.Username,
                    RecipeName = x.RecipeName,
                    RecipeOrigin = x.RecipeOrigin.RecipeOriginName,
                    RecipeCookTime = x.RecipeCookTime
                });
            }
            return newRecipesList;
        }
        public async Task<GetRecipeDetailVM> GetRecipeDetail(int id)
        {
            //var RecipeInfos = await _unitOfWork.Recipes.GetEager(id);
            var RecipeIngredientInfos = await _unitOfWork.RecipeIngredientGroups.GetEager(id);
            var RecipeReviewInfos = await _unitOfWork.RecipeReviews.GetByRecipeEager(id);
            if(RecipeIngredientInfos == null || RecipeReviewInfos == null)
            {
                return null;
            }
            GetRecipeDetailVM RecipeDetails = new GetRecipeDetailVM()
            {
                RecipeInfos = RecipeIngredientInfos,
                RecipeReviews = RecipeReviewInfos
            };           
            return RecipeDetails;
        }
    }
}
