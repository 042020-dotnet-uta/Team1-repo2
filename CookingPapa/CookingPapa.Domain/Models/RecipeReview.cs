using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class RecipeReview
    {
        public int Id { get; set; }
        public User User{ get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeReviewRating { get; set; }
        public string RecipeReviewComment { get; set; }
    }
}
