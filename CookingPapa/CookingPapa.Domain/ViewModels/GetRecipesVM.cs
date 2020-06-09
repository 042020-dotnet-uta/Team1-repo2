

namespace CookingPapa.Domain.ViewModels
{
    public class GetRecipesVM
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string RecipeName { get; set; }
        public string RecipeOrigin { get; set; }
        public int RecipeCookTime { get; set; }

    }
}
