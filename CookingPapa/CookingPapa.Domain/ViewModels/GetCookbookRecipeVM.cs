using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    public class GetCookbookRecipeVM
    {
        public int RecipeId { get; set; }
        public int CookbookId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeOrigin { get; set; }
    }
}
