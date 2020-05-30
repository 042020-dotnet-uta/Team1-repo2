using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingPapa.Data;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using CookingPapa.Domain;
using Microsoft.Extensions.Logging;
using SQLitePCL;
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
        public async Task<ActionResult<List<GetRecipesVM>>> GetRecipes()
        {
            //for searching all recipeVM
            //return all the recipeVM with all of its components without ratings
            //return _unitOfWork.Recipes.GetAllEager().Result.ToList();
            return await _businessL.GetRecipes();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetRecipeDetailVM>> GetRecipe(int id)
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

        // PUT: api/Recipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, RecipeVM recipeVM)
        {
            //for editting a recipeVM angular will send over a recipeVM object with 
            //editted informations. Need to remember to add functionality to add and remove
            //ingredients of a recipe. before any functionality is performed we need to retrieve the original
            //recipe information so it can be compared with the editted recipe.
            if (id != recipeVM.RecipeId)
            {
                return BadRequest();
            }

            //_context.Entry(recipeVM).State = EntityState.Modified;

            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(RecipeVM recipeVM)
        {
            //For Creating a new Recipe will accept RecipeVM object from Angular
            //need to translate that object into query readable to update db
            
            

            return CreatedAtAction("GetRecipe", new { id = recipeVM.RecipeId }, recipeVM);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Recipe>> DeleteRecipe(int id)
        {
            //delete recipe
            var recipe = await _unitOfWork.Recipes.Get(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _unitOfWork.Recipes.Delete(id);
            var returnVal = await _unitOfWork.Complete();
            //Check the return value?

            return recipe;
        }

        private bool RecipeExists(int id)
        {
            var recipe = _unitOfWork.Recipes.Get(id).Result;
            return (recipe == null);
        }
    }
}
