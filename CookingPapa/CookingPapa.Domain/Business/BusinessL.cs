using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
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
<<<<<<< HEAD
        public async Task<RecipeInformationVM> GetRecipeDetail(int id)
=======

        public async Task<List<GetRecipesVM>> GetRecipes(string searchPattern)
        {
            var recipes = await _unitOfWork.Recipes.FindEager(r => r.RecipeName.Contains(searchPattern));
            List<GetRecipesVM> newRecipesList = new List<GetRecipesVM>();
            foreach (var x in recipes)
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
>>>>>>> cf7be2b5848efcd2b1db3a809a91e67ce3132ce3
        {
            var RecipeIngredientInfos = await _unitOfWork.RecipeIngredientGroups.GetByRecipeEager(id);
            var RecipeReviewInfos = await _unitOfWork.RecipeReviews.GetByRecipeEager(id);
            double averageRating=0;
            List<RecipeIngredientGroupVM> recipeIngredientGroupVMs = new List<RecipeIngredientGroupVM>();
            List<RecipeInformationReviewVM> recipeInformationReviewVMs = new List<RecipeInformationReviewVM>();
            foreach (var x in RecipeIngredientInfos)
            {
                recipeIngredientGroupVMs.Add(
                    new RecipeIngredientGroupVM()
                    {
                        IngredientName = x.RecipeIngredient.RecipeIngredientName,
                        MeasurementName = x.RecipeMeasurement.RecipeMeasurementName,
                        IngredientAmount = x.RecipeIngredientAmount
                    });
            };
            if (RecipeReviewInfos.Any())
            {

                foreach (var y in RecipeReviewInfos)
                {
                    recipeInformationReviewVMs.Add(
                        new RecipeInformationReviewVM()
                        {
                            Username = y.User.Username,
                            RecipeReviewComment = y.RecipeReviewComment,
                            RecipeReviewRating = y.RecipeReviewRating
                        });
                };
                averageRating = Math.Round(recipeInformationReviewVMs.Average(x => x.RecipeReviewRating),2);
            }
            RecipeInformationVM RecipeDetails = new RecipeInformationVM()
            {
                RecipeId = id,
                RecipeName = RecipeIngredientInfos.First().Recipe.RecipeName,
                RecipeOrigin = RecipeIngredientInfos.First().Recipe.RecipeOrigin.RecipeOriginName,
                RecipeCooktime = RecipeIngredientInfos.First().Recipe.RecipeCookTime,
                RecipeDescription = RecipeIngredientInfos.First().Recipe.RecipeInstruction,
                RecipeCreator = RecipeIngredientInfos.First().Recipe.User.Username,
                RecipeAverageRating = averageRating,
                RecipeIngredientGroupVMs = recipeIngredientGroupVMs,
                recipeReviewVMs = recipeInformationReviewVMs
            };

            return RecipeDetails;
        }
        public async Task<Recipe> PostRecipe(PostRecipeVM recipeVM)
        {
            AddNewIngredientAndUnit(recipeVM);

            var recipeOrigins = await _unitOfWork.RecipeOrigins.GetAll();
                
            var recipeOrigin = recipeOrigins.ToList().Find(x => x.RecipeOriginName == recipeVM.RecipeOriginName); 
            if (recipeOrigin == null)
            {
                recipeOrigin = new RecipeOrigin()
                {
                    RecipeOriginName = recipeVM.RecipeOriginName
                };
                _unitOfWork.RecipeOrigins.Add(recipeOrigin);
            }

            var user = _unitOfWork.Users.Get(recipeVM.UserId).Result;
            await _unitOfWork.Complete();
            Recipe recipe = new Recipe()
            {
                User = user,
                RecipeOrigin = recipeOrigin,
                RecipeName = recipeVM.RecipeName,
                RecipeCookTime = recipeVM.RecipeCookTime,
                RecipeInstruction = recipeVM.RecipeInstruction
            };
            List<RecipeIngredientGroups> recipeIngredientGroups = new List<RecipeIngredientGroups>();
            var ingredientId = _unitOfWork.RecipeIngredients.GetAll().Result.ToList();
            var measurementId = _unitOfWork.RecipeMeasurements.GetAll().Result.ToList();
            foreach (var x in recipeVM.RecipeIngredientGroupVM)
            {
                var ingredientIds = ingredientId.Find(y => y.RecipeIngredientName == x.IngredientName).Id;
                var measurementIds = measurementId.Find(y => y.RecipeMeasurementName == x.MeasurementName).Id;
                recipeIngredientGroups.Add(new RecipeIngredientGroups()
                {
                    Recipe = recipe,
                    RecipeIngredient = _unitOfWork.RecipeIngredients.Get(ingredientIds).Result,
                    RecipeMeasurement = _unitOfWork.RecipeMeasurements.Get(measurementIds).Result,
                    RecipeIngredientAmount = x.IngredientAmount
                });
            }
            _unitOfWork.Recipes.Add(recipe);
            _unitOfWork.RecipeIngredientGroups.AddRange(recipeIngredientGroups);
            await _unitOfWork.Complete();
            //var newRecipe = _unitOfWork.Recipes.GetAll().Result.Last();
            return recipe;
        }
        public async Task<RecipeInformationVM> PutRecipe(PostRecipeVM recipeVM)
        {
            //var oldRecipe = await _unitOfWork.RecipeIngredientGroups.GetEager(recipeVM.RecipeId);
            var updateRecipe = await PostRecipe(recipeVM);
            var deletedRecipe = await DeleteRecipe((int)recipeVM.RecipeId);
            var newRecipe = await GetRecipeDetail(updateRecipe.Id);
            await _unitOfWork.Complete();
            return newRecipe;
        }
        
        public async Task<Recipe> DeleteRecipe(int id)
        {
            await _unitOfWork.RecipeIngredientGroups.DeleteAll(id);
            var recipeDeleted = await _unitOfWork.Recipes.Delete(id);
            return recipeDeleted;
        }

        public async Task<InformationVM> GetInformation()
        {
            var origins = await _unitOfWork.RecipeOrigins.GetAll();
            var origins1 = origins.Select(x=>x.RecipeOriginName).ToArray();
            var ingredients = await _unitOfWork.RecipeIngredients.GetAll();
            var ingredients1 = ingredients.Select(x=>x.RecipeIngredientName).ToArray();
            var units = await _unitOfWork.RecipeMeasurements.GetAll();
            var units1 = units.Select(x=>x.RecipeMeasurementName).ToArray();
            var information = new InformationVM()
            {
                Origins = origins1,
                Ingredients = ingredients1,
                MeasurementUnits = units1
            };
            return information;
        }

        public async Task<RecipeReview> PutRecipeReview(RecipeReviewVM recipeReview)
        {
            var edittedReview = await functionForReview(recipeReview);
            _unitOfWork.RecipeReviews.Update(edittedReview);
            await _unitOfWork.Complete();
            return edittedReview;
        }

        public async Task<RecipeReview> PostRecipeReview(RecipeReviewVM recipeReview)
        {
            var editReview = await functionForReview(recipeReview);
            editReview = await _unitOfWork.RecipeReviews.Add(editReview);
            await _unitOfWork.Complete();
            return editReview;
        }

        public async Task<User> CreateUser(User user)
        {
            var listOfUsers = await _unitOfWork.Users.GetAll();
            var checkUserName = listOfUsers.Select(x => x.Username).ToList().Find(x => x == user.Username);
            if (checkUserName == null)
            {
                await _unitOfWork.Users.Add(user);
                await _unitOfWork.Complete();
                return user;
            }
            return null;
        }






        public async Task<RecipeReview> functionForReview(RecipeReviewVM recipeReview)
        {
            var user = await _unitOfWork.Users.Get(recipeReview.UserId);
            var recipe = await _unitOfWork.Recipes.Get(recipeReview.RecipeId);
            var edittedReview = new RecipeReview()
            {
                User = user,
                Recipe = recipe,
                Id = recipeReview.RecipeReviewId,
                RecipeReviewRating = recipeReview.RecipeReviewRating,
                RecipeReviewComment = recipeReview.RecipeReviewComment
            };
            return edittedReview;
        }
        //Function used for post/put recipe.
        //checks all the ingredient user selected with the database, if it does not exist in db, it adds
        //the ingredient to the db.
        public bool AddNewIngredientAndUnit(PostRecipeVM recipeVM)
        {
            var checkIngredientExists = _unitOfWork.RecipeIngredients.GetAll().Result.ToList();
            var checkMeasurementExists = _unitOfWork.RecipeMeasurements.GetAll().Result.ToList();

            foreach (var x in recipeVM.RecipeIngredientGroupVM)
            {               
                var checkIngredientExist = checkIngredientExists.Find(y => y.RecipeIngredientName == x.IngredientName);
                if (checkIngredientExist == null)
                {
                    _unitOfWork.RecipeIngredients.Add(new RecipeIngredient() { RecipeIngredientName = x.IngredientName });
                }
                var checkMeasurementExist = checkMeasurementExists.Find(y => y.RecipeMeasurementName == x.MeasurementName);
                if (checkMeasurementExist == null)
                {
                    _unitOfWork.RecipeMeasurements.Add(new RecipeMeasurement() { RecipeMeasurementName = x.MeasurementName });
                }
            }
            //save the change so that ingredient group can be added to the db below.
            //_unitOfWork.Complete();
            return true;
        }
    }

}
