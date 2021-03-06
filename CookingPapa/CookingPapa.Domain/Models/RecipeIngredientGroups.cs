﻿
using System.ComponentModel.DataAnnotations;

namespace CookingPapa.Domain.Models
{
    public class RecipeIngredientGroups
    {
        [Display(Name = "Recipe Ingredient Details ID")]
        public int Id { get; set; }

        [Display(Name = "Recipe")]
        [Required]
        public Recipe Recipe { get; set; }

        [Display(Name = "Recipe Ingredient")]
        [Required]
        public RecipeIngredient RecipeIngredient { get; set; }

        [Display(Name = "Unit of Measurement")]
        [Required]
        public RecipeMeasurement RecipeMeasurement { get; set; }

        [Required]
        public int RecipeIngredientAmount { get; set; }
    }
}
