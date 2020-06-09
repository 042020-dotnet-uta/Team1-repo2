

namespace CookingPapa.Domain.ViewModels
{
    public class GetCookbookVM
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public int CookbookId { get; set; }
        public string RecipeName { get; set; }
        public string RecipeOrigin { get; set; }
        public int RecipeCookTime { get; set; }
    }
}
