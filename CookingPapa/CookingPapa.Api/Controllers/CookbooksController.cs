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
using Microsoft.Extensions.DependencyModel.Resolution;

namespace CookingPapa.Api.Controllers
{
    [Route("api/Cookbooks")]
    [ApiController]
    public class CookbooksController : ControllerBase
    {
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
        public async Task<ActionResult<List<GetCookbookVM>>> GetCookbook(int id)
        {
            try
            {
                //returns list of recipes in the user cookbook.
                var cookbook = await _businessL.GetCookbook(id);
                if (cookbook == null)
                {
                    return NotFound();
                }
                return cookbook;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in CookbooksController.GetCookbook: {e}");
                return StatusCode(500);
            }
            
        }
        /// <summary>
        /// POST: api/Cookbooks
        /// Adds the selected recipe into user cookbook
        /// </summary>
        /// <param name="cookbook">Instance of PostCookbookVM returned from Angular that includes
        /// user id and recipe id</param>
        /// <returns>Returns information of the entries added</returns>
        [HttpPost("")]
        public async Task<ActionResult<Cookbook>> PostCookbook(PostCookbookVM cookbook)
        {
            try
            {
                var addedCookbook = await _businessL.PostCookbook(cookbook);
                if (addedCookbook == null)
                {
                    return NoContent();
                }
                return addedCookbook;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in CookbooksController.PostCookbook: {e}");
                return StatusCode(500);
            }
            
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
            try
            {
                //there should be a remove from Cookbook button by the list of recipe under cookbook that
                //directs user here.
                var cookbook = await _unitOfWork.Cookbooks.GetEager(id);
                if (cookbook == null)
                {
                    return NotFound();
                }
                _unitOfWork.Cookbooks.Delete(id);
                await _unitOfWork.Complete();
                return cookbook;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in CookbooksController.DeleteCookbook: {e}");
                return StatusCode(500);
            }
            
        }

        private bool CookbookExists(int id)
        {
            var cookBook = _unitOfWork.Cookbooks.Get(id).Result;
            return (cookBook == null);
        }
    }
}
