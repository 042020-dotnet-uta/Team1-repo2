using CookingPapa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CookingPapa.Data
{
    public class CookingpapaContext:DbContext
    {
        public CookingpapaContext(DbContextOptions<CookingpapaContext> options) : base(options) { }

        public DbSet<Cookbook> CookBook{ get; set; }
        public DbSet<Recipe> Recipes{ get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients{ get; set; }
        public DbSet<RecipeIngredientGroups> RecipeIngredientGroups{ get; set; }
        public DbSet<RecipeMeasurement> RecipeMeasurements{ get; set; }
        public DbSet<RecipeOrigin> RecipeOrigins{ get; set; }
        public DbSet<RecipeReview> RecipeReviews{ get; set; }
        public DbSet<User> User{ get; set; }
    }
}
