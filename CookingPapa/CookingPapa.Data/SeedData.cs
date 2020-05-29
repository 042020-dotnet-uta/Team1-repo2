using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CookingPapa.Domain.Models;
using System.Threading;
using System.Xml.Linq;

namespace CookingPapa.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CookingpapaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CookingpapaContext>>()))
            {
                // look for any product/store in the DB
                if (context.User.Any())
                {
                    return; // DB already has something
                }
                #region Add Users
                var user1 = new User
                {
                    Email = "seedTest@gmail.com",
                    Username = "seedTest",
                    Password = "testSeed"
                };
                var user2 = new User
                {
                    Email = "seedTest2@test.com",
                    Username = "seedTest2",
                    Password = "testSeed2"
                };
                context.User.AddRange(
                    user1, 
                    user2
                );
                #endregion

                #region Add Ingredients
                var salt = new RecipeIngredient
                {
                    RecipeIngredientName = "Salt"
                };
                var butter = new RecipeIngredient
                {
                    RecipeIngredientName = "Butter"
                };
                var pepper = new RecipeIngredient
                {
                    RecipeIngredientName = "Pepper"
                };
                var chicken = new RecipeIngredient
                {
                    RecipeIngredientName = "Chicken"
                };
                var beer = new RecipeIngredient
                {
                    RecipeIngredientName = "Beer"
                };
                var water = new RecipeIngredient
                {
                    RecipeIngredientName = "Water"
                };
                context.AddRange(
                    salt,
                    butter,
                    pepper,
                    chicken,
                    beer,
                    water
                );
                #endregion

                #region Add Measurements
                var cups = new RecipeMeasurement
                {
                    RecipeMeasurementName = "Cups"
                };
                var tblsp = new RecipeMeasurement
                {
                    RecipeMeasurementName = "Tablespoons"
                };
                var tsp = new RecipeMeasurement
                {
                    RecipeMeasurementName = "Teaspoons"
                };
                var ounces = new RecipeMeasurement
                {
                    RecipeMeasurementName = "Ounces"
                };
                context.AddRange(
                    cups,
                    tblsp,
                    tsp,
                    ounces
                );
                #endregion

                #region Add Recipe Origins
                var origin1 = new RecipeOrigin
                {
                    RecipeOriginName = "Italian"
                };
                var origin2 = new RecipeOrigin
                {
                    RecipeOriginName = "German"
                };
                context.AddRange(
                    origin1,
                    origin2
                );
                #endregion

                #region Add Recipes
                var recipe1 = new Recipe
                {
                    RecipeCookTime = 45,
                    RecipeName = "Good Food",
                    RecipeInstruction = "Cook the food and stuff",
                    RecipeOrigin = origin1,
                    User = user1
                };
                var recipe2 = new Recipe
                {
                    RecipeCookTime = 60,
                    RecipeName = "Super Good Food",
                    RecipeInstruction = "Cook the damn food ",
                    RecipeOrigin = origin2,
                    User = user2
                };
                context.AddRange(
                    recipe1,
                    recipe2
                );
                #endregion

                #region Add RecipeIngrediantGroups
                context.AddRange(
                    new RecipeIngredientGroups
                    {
                        Recipe = recipe1,
                        RecipeIngredient = beer,
                        RecipeMeasurement = ounces,
                        RecipeIngredientAmount = 36
                    },
                    new RecipeIngredientGroups
                    {
                        Recipe = recipe1,
                        RecipeIngredient = salt,
                        RecipeMeasurement = tsp,
                        RecipeIngredientAmount = 1
                    },
                    new RecipeIngredientGroups
                    {
                        Recipe = recipe1,
                        RecipeIngredient = pepper,
                        RecipeMeasurement = tblsp,
                        RecipeIngredientAmount = 2
                    }
                ); 
                context.AddRange(
                     new RecipeIngredientGroups
                     {
                         Recipe = recipe2,
                         RecipeIngredient = chicken,
                         RecipeMeasurement = ounces,
                         RecipeIngredientAmount = 24
                     },
                     new RecipeIngredientGroups
                     {
                         Recipe = recipe2,
                         RecipeIngredient = salt,
                         RecipeMeasurement = tblsp,
                         RecipeIngredientAmount = 1
                     },
                     new RecipeIngredientGroups
                     {
                         Recipe = recipe2,
                         RecipeIngredient = butter,
                         RecipeMeasurement = tblsp,
                         RecipeIngredientAmount = 2
                     },
                     new RecipeIngredientGroups
                     {
                         Recipe = recipe2,
                         RecipeIngredient = pepper,
                         RecipeMeasurement = tsp,
                         RecipeIngredientAmount = 2
                     }
                 );
                #endregion

                #region Add RecipeReviews

                #endregion

                #region Add CookBooks
                var cookBook1 = new Cookbook
                {
                    User = user1,
                    Recipe = recipe1
                };
                var cookBook2 = new Cookbook
                {
                    User = user1,
                    Recipe = recipe2
                };
                context.AddRange(
                    cookBook1,
                    cookBook2
                    );
                #endregion

                context.SaveChanges();
            }
        }
    }
}
