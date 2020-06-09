using System;
using System.ComponentModel.DataAnnotations;

namespace CookingPapa.Domain.Models
{
    public class Recipe
    {
        [Display(Name = "Recipe")]
        public int Id { get; set; }

        [Display(Name = "User")]
        [Required]
        public User User { get; set; }

        [Display(Name = "Cultural Origin")]
        public RecipeOrigin RecipeOrigin { get; set; }

        [Display(Name = "Recipe Name")]
        [MinLength(0), MaxLength(80)]
        [Required]
        public string RecipeName { get; set; }

        [Display(Name = "Recipe Cooking Time")]
        [Range(0, 99999)]
        [Required]
        public int RecipeCookTime { get; set; }

        [Display(Name = "Recipe Instructions")]
        [MinLength(0)]
        [Required]
        public string RecipeInstruction { get; set; }
    }
}
