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

namespace CookingPapa.Api.Controllers
{
    [Route("api/Cookbooks")]
    [ApiController]
    public class CookbooksController : ControllerBase
    {
        //This part should be changed to the repository or business logic 
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public CookbooksController(IUnitOfWork unitOfWork, ILogger<CookbooksController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// GET: api/Cookbooks/1
        /// For displaying a list of recipe under user cookbook
        /// </summary>
        /// <param name="id">This should be user Id to filter cookbook recipes</param>
        /// <returns>Returns a list of cookbook recipe for the selected user</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Cookbook>>> GetCookbook(int id)
        {
            
            //return the specific cook book with the list of recipes.
            var cookbook = _unitOfWork.Cookbooks.GetByUserEager(id).Result.ToList();
            //if using deep link user enters id that does not exists
            if (cookbook == null)
            {
                return NotFound();
            }
            return cookbook;
        }
        // POST: api/Cookbooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("")]
        public async Task<ActionResult<Cookbook>> PostCookbook(Cookbook cookbook)
        {
/*            var checkIfExists = _unitOfWork.Cookbooks.GetByUserEager(cookbook.User.Id)
                            .Result.ToList().Find(x => x.Recipe.Id == cookbook.Recipe.Id);
                        if (checkIfExists == null)
                        {
*/              //there should be a button that says add to cookbook that will send a post request here.
            cookbook.User = await _unitOfWork.Users.Get(cookbook.User.Id);
            cookbook.Recipe = await _unitOfWork.Recipes.GetEager(cookbook.Recipe.Id);
            _unitOfWork.Cookbooks.Add(cookbook);
                await _unitOfWork.Complete();
                return cookbook;
            //}
            //return NoContent();


            //GetCook takes user id to filter out all the recipe in a cookbook,
            //return CreatedAtAction("GetCookbook", new { id = cookbook.Id }, cookbook);
        }
        /// <summary>
        /// DELETE: api/Cookbooks/1/5
        /// For deleting a recipe from a user cookbook
        /// </summary>
        /// <param name="id">This should be cookbook id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cookbook>> DeleteCookbook(int id)
        {
            //there should be a remove from Cookbook button by the list of recipe under cookbook that
            //directs user here.
            var cookbook = await _unitOfWork.Cookbooks.GetEager(id);
            if (cookbook == null)
            {
                return NotFound();
            }
            _unitOfWork.Cookbooks.Delete(id);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Complete();

            return cookbook;
        }

        private bool CookbookExists(int id)
        {
            var cookBook = _unitOfWork.Cookbooks.Get(id).Result;
            return (cookBook == null);
        }
    }
}
