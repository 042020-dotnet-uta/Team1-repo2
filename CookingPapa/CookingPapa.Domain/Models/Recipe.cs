using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public User User { get; set; }
        public RecipeOrigin RecipeOrigin { get; set; }
        public string RecipeName { get; set; }
        public int RecipeCookTime { get; set; }
        public string RecipeInstruction { get; set; }
    }
}
