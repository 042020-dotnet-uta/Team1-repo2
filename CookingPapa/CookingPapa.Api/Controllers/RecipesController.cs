using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using CookingPapa.Domain;
using Microsoft.Extensions.Logging;
using CookingPapa.Domain.Business;

namespace CookingPapa.Api.Controllers
{
    [Route("api/Recipes")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        //This part should be changed to the repository or business logic 
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RecipesController> _logger;
        private readonly IBusinessL _businessL;

        public RecipesController(IUnitOfWork unitOfWork, ILogger<RecipesController> logger,
            IBusinessL businessL)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _businessL = businessL;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<List<GetRecipesVM>>> GetRecipes(string searchpattern)
        {
            //for searching all recipeVM
            //return all the recipeVM with all of its components without ratings
            //return _unitOfWork.Recipes.GetAllEager().Result.ToList();
            try
            {
                if (String.IsNullOrEmpty(searchpattern?.Trim()))
                {
                    return await _businessL.GetRecipes();
                }
                else
                {
                    return await _businessL.GetRecipes(searchpattern);
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in RecipesController.GetRecipes: {e}");
                return StatusCode(500);
            }
            
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeInformationVM>> GetRecipe(int id)
        {
            try
            {
                //the list of recipeVM we are searching from need to include all the information
                //including origin, cook time, ingredient and reviews
                var recipe = await _businessL.GetRecipeDetail(id);
                if (recipe == null)
                {
                    return NotFound();
                }
                return recipe;
            } 
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in RecipesController.GetRecipe: {e}");
                return StatusCode(500);
            }
            
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<RecipeInformationVM> PutRecipe(PostRecipeVM recipeVM)
        {
            //for editting a recipeVM angular will send over a recipeVM object with 
            //editted informations. Need to remember to add functionality to add and remove
            //ingredients of a recipe. before any functionality is performed we need to retrieve the original
            //recipe information so it can be compared with the editted recipe.
            //_context.Entry(recipeVM).State = EntityState.Modified;
            var editRecipe = await _businessL.PutRecipe(recipeVM);     
            return editRecipe;
            //return CreatedAtAction("GetRecipe", new { id = editRecipe.RecipeInfos.Id }, editRecipe);
        }

        // POST: api/Recipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(PostRecipeVM recipeVM)
        {
            //PostRecipeVM recipeVM
            //For Creating a new Recipe will accept PostRecipeVM object from Angular
            //need to translate that object into query readable to update db
            try
            {
                var recipeCreated = await _businessL.PostRecipe(recipeVM);            
                return CreatedAtAction("GetRecipe", new { id = recipeCreated.Id }, recipeCreated);
                //return null;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in RecipesController.PostRecipe: {e}");
                return StatusCode(500);
            }
            
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<Recipe> DeleteRecipe(int id)
        {
            //delete recipe
            var deletedRecipe = await _businessL.DeleteRecipeWithReview(id);

            //Check the return value?

            return deletedRecipe;
        }

        private bool RecipeExists(int id)
        {
            var recipe = _unitOfWork.Recipes.Get(id).Result;
            return (recipe == null);
        }
    }
}
