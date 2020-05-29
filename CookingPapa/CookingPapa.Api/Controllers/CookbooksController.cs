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
using CookingPapa.Domain.ViewModels;
using CookingPapa.Domain.Business;

namespace CookingPapa.Api.Controllers
{
    [Route("api/Cookbooks")]
    [ApiController]
    public class CookbooksController : ControllerBase
    {
        //This part should be changed to the repository or business logic 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessL _businessL;
        private readonly ILogger _logger;


        public CookbooksController(IUnitOfWork unitOfWork, ILogger<CookbooksController> logger
            ,IBusinessL businessL)
        {
            _unitOfWork = unitOfWork;
            _businessL = businessL;
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
        public async Task<ActionResult<Cookbook>> PostCookbook(PostCookbookVM cookbook)
        {
            var addedCookbook = await _businessL.PostCookbook(cookbook);
            if (addedCookbook == null)
            {
                return NoContent();
            }
            return addedCookbook;
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
