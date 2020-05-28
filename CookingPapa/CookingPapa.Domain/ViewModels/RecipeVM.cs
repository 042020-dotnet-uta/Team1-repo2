using CookingPapa.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.ViewModels
{
    //this class will be used specifically for creating a recipe and editting a recipe.
    //Angular will send all the needed info in this object format
    public class RecipeVM
    {
        //Id if provided is matched with a recipe in database to edit. If none provided we will add it to the 
        //database
        public int? RecipeId { get; set; }
        //use the given origin name to check with db, if the same ignore, if different or new change the 
        //origin object within editted recipe
        public int RecipeOriginName { get; set; }
        public string RecipeName { get; set; }
        public int RecipeCookTime { get; set; }
        public string RecipeInstruction { get; set; }
        //put the list of ingredient groups into a list and compare against database with for each.
        //If there is a new ingredient group we add to the recipe, if missing an ingredient group, delete it.
        public List<RecipeIngredientGroups> recipeIngredientGroups { get; set; }    
    }
}
