using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Models
{
    public class RecipeIngredientGroups
    {
        public int Id { get; set; }
        public Recipe Recipe { get; set; }
        public RecipeIngredient RecipeIngredient { get; set; }
        public RecipeMeasurement RecipeMeasurement { get; set; }
        public int RecipeIngredientAmount { get; set; }
    }
}
