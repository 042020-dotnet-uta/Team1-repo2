
using System.ComponentModel.DataAnnotations;

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
