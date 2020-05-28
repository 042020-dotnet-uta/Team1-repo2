using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CookingPapa.Data;
using CookingPapa.Domain.Models;

namespace CookingPapa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbooksController : ControllerBase
    {
        //This part should be changed to the repository or business logic 
        private readonly CookingpapaContext _context;

        public CookbooksController(CookingpapaContext context)
        {
            _context = context;
        }

        // GET: api/Cookbooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cookbook>> GetCookbook(int id)
        {
            //return the specific cook book with the list of recipes.
            var cookbook = await _context.CookBook.FindAsync(id);

            if (cookbook == null)
            {
                return NotFound();
            }

            return cookbook;
        }

        // POST: api/Cookbooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cookbook>> PostCookbook(Cookbook cookbook)
        {
            //there should be a button that says add to cookbook that will send a post request here.
            _context.CookBook.Add(cookbook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCookbook", new { id = cookbook.Id }, cookbook);
        }

        // DELETE: api/Cookbooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cookbook>> DeleteCookbook(int id)
        {
            //there should be a remove from Cookbook button by the list of recipe under cookbook that
            //directs user here.
            var cookbook = await _context.CookBook.FindAsync(id);
            if (cookbook == null)
            {
                return NotFound();
            }

            _context.CookBook.Remove(cookbook);
            await _context.SaveChangesAsync();

            return cookbook;
        }

        private bool CookbookExists(int id)
        {
            return _context.CookBook.Any(e => e.Id == id);
        }
    }
}
