using System;
using System.ComponentModel.DataAnnotations;

namespace CookingPapa.Domain.Models
{
    public class RecipeReview
    {
        [Display(Name = "Recipe Review ID")]
        public int Id { get; set; }

        [Display(Name = "Review User")]
        [Required]
        public User User{ get; set; }

        [Display(Name = "Reviewed Recipe")]
        [Required]
        public Recipe Recipe { get; set; }

        [Display(Name = "Review Rating")]
        [Range(0,5)]
        [Required]
        public int RecipeReviewRating { get; set; }

        [Display(Name = "Review Comment")]
        [MinLength(0), MaxLength(512)]
        [Required]
        public string RecipeReviewComment { get; set; }
    }
}
