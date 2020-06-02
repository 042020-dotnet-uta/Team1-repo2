using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class RecipeIngredient
    {
        [Display(Name = "Ingredient ID")]
        public int Id { get; set; }

        [Display(Name = "Ingredient Name")]
        [MinLength(0)]
        [Required]
        public string RecipeIngredientName { get; set; }
    }
}
