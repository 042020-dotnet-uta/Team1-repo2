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

namespace CookingPapa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        //This part should be changed to the repository or business logic 
        private readonly CookingpapaContext _context;

        public RecipesController(CookingpapaContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            //for searching all recipeVM
            //return all the recipeVM with all of its components without ratings
            return await _context.Recipes.ToListAsync();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            //the list of recipeVM we are searching from need to include all the information
            //including origin, cook time, ingredient and reviews
            var recipe = await _context.Recipes.FindAsync(id);

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

            _context.Entry(recipeVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();

            return recipe;
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }
    }
}
