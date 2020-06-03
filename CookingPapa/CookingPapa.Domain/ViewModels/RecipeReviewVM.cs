using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    public class RecipeReviewVM
    {
        public int? RecipeReviewId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public int RecipeReviewRating { get; set; }
        public string RecipeReviewComment { get; set; }
    }
}
