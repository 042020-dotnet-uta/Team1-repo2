using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    public class GetRecipeDetailVM
    {
        //Recipe info
        public RecipeIngredientGroups RecipeInfos { get; set; }
        //Recipe Reviews info
        public List<RecipeReview> RecipeReviews { get; set; }
    }
}
