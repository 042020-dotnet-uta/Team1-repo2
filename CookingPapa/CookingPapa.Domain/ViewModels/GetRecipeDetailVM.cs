using CookingPapa.Domain.Models;
using System.Collections.Generic;
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
