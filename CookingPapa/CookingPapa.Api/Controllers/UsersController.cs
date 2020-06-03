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

namespace CookingPapa.Api.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RecipesController> _logger;
        private readonly IBusinessL _businessL;

        public UsersController(IUnitOfWork unitOfWork, ILogger<RecipesController> logger,
            IBusinessL businessL)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _businessL = businessL;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<User>> GetUser()
        {
            return await _unitOfWork.Users.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(id);

                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception e)
            {
                _logger.LogError($"Exception in UsersController.GetUser: {e}");
                return StatusCode(500);
            }
            
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Users.Update(user);
            try
            {
                await _unitOfWork.Complete();
            }
            catch (DbUpdateConcurrencyException)
            {
                _logger.LogError("Error: Database Concurrency failure in UsersController.PutUser");
                return StatusCode(500);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in UsersController.PutUser: {e}");
                return StatusCode(500);
            }
            return user;
        }
        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                var createdUser = await _businessL.CreateUser(user);
                if (createdUser == null)
                {
                    return NoContent();
                }
                return user;
            } 
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in UserController.PostUser: {e}");
                return StatusCode(500);
            }
            
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var user = await _unitOfWork.Users.Get(id);
                if (user == null)
                {
                    return NotFound();
                }
                await _unitOfWork.Users.Delete(id);
                await _unitOfWork.Complete();

                return user;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error: Exception thrown in UserController.DeleteUser: {e}");
                return StatusCode(500);
            }
            
        }
    }
}
