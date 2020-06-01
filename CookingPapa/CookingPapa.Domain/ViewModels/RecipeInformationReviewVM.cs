using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    public class RecipeInformationReviewVM
    {
        public string Username { get; set; }
        public int RecipeReviewRating { get; set; }
        public string RecipeReviewComment { get; set; }
    }
}
