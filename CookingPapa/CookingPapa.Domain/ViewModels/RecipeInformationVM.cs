using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    public class RecipeInformationVM
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeOrigin { get; set; }
        public int RecipeCooktime { get; set; }
        public string RecipeDescription { get; set; }
        public string RecipeCreator { get; set; }
        public int? RecipeCreatorId{ get; set; }
        public double RecipeAverageRating { get; set; }
        public List<RecipeIngredientGroupVM> RecipeIngredientGroupVMs { get; set; }
        public List<RecipeInformationReviewVM> recipeReviewVMs { get; set; }
    }
}
