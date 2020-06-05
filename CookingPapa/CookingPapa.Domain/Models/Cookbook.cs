
using System.ComponentModel.DataAnnotations;

namespace CookingPapa.Domain.Models
{
    public class Cookbook
    {
        [Display(Name = "Cookbook Entry ID")]
        public int Id { get; set; }

        /*        public int UserId { get; set; }
                public int RecipeId { get; set; }
        */

        [Display(Name = "User")]
        [Required]
        public User User { get; set; }

        [Display(Name = "Recipe")]
        [Required]
        public Recipe Recipe { get; set; }
    }
}
