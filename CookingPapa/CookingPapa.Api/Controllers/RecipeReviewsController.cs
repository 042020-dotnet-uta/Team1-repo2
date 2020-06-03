using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingPapa.Data;
using CookingPapa.Domain.Models;
using CookingPapa.Domain;
using Microsoft.Extensions.Logging;
using CookingPapa.Domain.Business;
using CookingPapa.Domain.ViewModels;
using Microsoft.CodeAnalysis.Differencing;

namespace CookingPapa.Api.Controllers
{
    [Route("api/RecipeReviews")]
    [ApiController]
    public class RecipeReviewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessL _businessL;
        private readonly ILogger _logger;
        public RecipeReviewsController(IUnitOfWork unitOfWork, ILogger<CookbooksController> logger
            , IBusinessL businessL)
        {
            _unitOfWork = unitOfWork;
            _businessL = businessL;
            _logger = logger;
        }
        // GET: api/RecipeReviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RecipeReviewVM>>> GetRecipeReview(int id)
        {
            //var recipeReview = await _unitOfWork.RecipeReviews.GetEager(id);
            var reviews = await _businessL.GetReviewsForRecipe(id);
            if (reviews == null)
            {
                return NotFound();
            }
            return reviews;
        }

        // PUT: api/RecipeReviews/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<RecipeReview>> PutRecipeReview(int id, RecipeReviewVM recipeReview)
        {
            if (id != recipeReview.RecipeReviewId)
            {
                return BadRequest();
            }
            try
            {
                var editReview = await _businessL.PutRecipeReview(recipeReview);
                return editReview;
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NotFound();
            }
        }
        // POST: api/RecipeReviews
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecipeReview>> PostRecipeReview(RecipeReviewVM recipeReview)
        {
            var newReview = await _businessL.PostRecipeReview(recipeReview);
            return newReview;          
        }

        // DELETE: api/RecipeReviews/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecipeReview>> DeleteRecipeReview(int id)
        {
            var deletedReview = await _unitOfWork.RecipeReviews.Delete(id);
            await _unitOfWork.Complete();

            return deletedReview;
        }
    }
}
