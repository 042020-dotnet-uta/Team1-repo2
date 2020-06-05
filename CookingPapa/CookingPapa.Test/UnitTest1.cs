using Xunit;
using Microsoft.EntityFrameworkCore;
using CookingPapa.Domain.Models;
using CookingPapa.Data;
using System.Linq;
using System.Collections.Generic;
using CookingPapa.Domain.Business;
using CookingPapa.Domain.ViewModels;

namespace CookingPapa.Test
{
    public class UnitTest1
    {
        /// <summary>
        /// Test 0 -- 
        /// Uses the Unit of Work to build repositories.
        /// </summary>
        [Fact]
        public void TestUnitOfWork()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test0DB")
                .Options;

            //Act

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                Assert.NotNull(_unitOfWork.Cookbooks);
                Assert.NotNull(_unitOfWork.Recipes);
                Assert.NotNull(_unitOfWork.RecipeIngredients);
                Assert.NotNull(_unitOfWork.RecipeIngredientGroups);
                Assert.NotNull(_unitOfWork.RecipeMeasurements);
                Assert.NotNull(_unitOfWork.RecipeOrigins);
                Assert.NotNull(_unitOfWork.RecipeReviews);
                Assert.NotNull(_unitOfWork.Users);
            }
        }

        /// <summary>
        /// Test 1 -- 
        /// Uses the generic repository to add an entity to the database.
        /// </summary>
        [Fact]
        public async void TestGenericAdd()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test1DB")
                .Options;

            //Act
            RecipeOrigin testOrigin;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "Test"
                };

                await _unitOfWork.RecipeOrigins.Add(testOrigin);
                await _unitOfWork.Complete();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                var origin = context.RecipeOrigins
                    .Where(orig => orig.RecipeOriginName == "Test").First();
                Assert.Equal(testOrigin.Id, origin.Id);
            }
        }

        /// <summary>
        /// Test 2 -- 
        /// Uses the generic repository to update an entity in the database.
        /// </summary>
        /* Update Unit Test currently inoperable
        [Fact]
        public void TestGenericUpdate()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test2DB")
                .Options;

            //Act
            RecipeOrigin testOrigin;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "Test"
                };

                _unitOfWork.RecipeOrigins.Add(testOrigin);
                _unitOfWork.Complete();

                RecipeOrigin newOrigin = new RecipeOrigin
                {
                    Id = 1,
                    RecipeOriginName = "UpdatedName"
                };

                _unitOfWork.RecipeOrigins.Update(newOrigin);
                _unitOfWork.Complete();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                var origin = context.RecipeOrigins
                    .Where(orig => orig.RecipeOriginName == "Test").First();
                Assert.Equal(testOrigin.Id, origin.Id);
            }
        }
        */

        /// <summary>
        /// Test 3 -- 
        /// Uses the generic repository to get an entity from the database.
        /// </summary>
        [Fact]
        public async void TestGenericGet()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test3DB")
                .Options;

            //Act
            RecipeOrigin testOrigin;
            RecipeOrigin testResultHolder;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "Test"
                };

                await _unitOfWork.RecipeOrigins.Add(testOrigin);
                await _unitOfWork.Complete();

                testResultHolder = await _unitOfWork.RecipeOrigins.Get(1);
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                var origin = context.RecipeOrigins
                    .Where(orig => orig.Id == 1).First();
                Assert.Equal("Test", testResultHolder.RecipeOriginName);
            }
        }

        /// <summary>
        /// Test 4 -- 
        /// Uses the generic repository to get all entities from the database.
        /// </summary>
        [Fact]
        public async void TestGenericGetAll()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test4DB")
                .Options;

            //Act
            List<RecipeOrigin> testOrigins;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "Test1"
                };

                var testOrigin2 = new RecipeOrigin
                {
                    RecipeOriginName = "Test2"
                };

                await _unitOfWork.RecipeOrigins.Add(testOrigin);
                await _unitOfWork.RecipeOrigins.Add(testOrigin2);
                await _unitOfWork.Complete();

                var tempTestOrigins = await _unitOfWork.RecipeOrigins.GetAll();
                testOrigins = tempTestOrigins.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal("Test1", testOrigins[0].RecipeOriginName);
                Assert.Equal("Test2", testOrigins[1].RecipeOriginName);
            }
        }

        /// <summary>
        /// Test 5 -- 
        /// Uses the Cookbook repository to delete an entity from the database.
        /// </summary>
        [Fact]
        public async void TestCookbookDelete()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test5DB")
                .Options;

            //Act
            List<Cookbook> cookbookElements;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testCookbook = new Cookbook
                {

                };

                await _unitOfWork.Cookbooks.Add(testCookbook);
                await _unitOfWork.Complete();

                _unitOfWork.Cookbooks.Delete(1);
                await _unitOfWork.Complete();

                var tempTestOrigins = await _unitOfWork.Cookbooks.GetAll();
                cookbookElements = tempTestOrigins.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Empty(cookbookElements);
            }
        }

        /// <summary>
        /// Test 6 -- 
        /// Uses the cookbook repository to eager load an entity from the database.
        /// </summary>
        [Fact]
        public async void TestCookbookGetEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test6DB")
                .Options;

            //Act
            Cookbook testResultCookbook;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testRecipe = new Recipe
                {

                };

                var testCookbook = new Cookbook
                {
                    User = testUser,
                    Recipe = testRecipe
                };

                await _unitOfWork.Cookbooks.Add(testCookbook);
                await _unitOfWork.Complete();

                var tempTestCookbook = await _unitOfWork.Cookbooks.GetEager(1);
                testResultCookbook = tempTestCookbook;
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal("TestUser", testResultCookbook.User.Username);
                Assert.Equal("TestPass", testResultCookbook.User.Password);
                Assert.Equal("Test@Test.Test", testResultCookbook.User.Email);
            }
        }

        /// <summary>
        /// Test 7 -- 
        /// Uses the cookbook repository to eager load all entities from the database based on a UserID.
        /// </summary>
        [Fact]
        public async void TestCookbookGetByUserEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test7DB")
                .Options;

            //Act
            List<Cookbook> testResultsCookbooks;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testRecipe = new Recipe
                {

                };

                var testCookbook = new Cookbook
                {
                    User = testUser,
                    Recipe = testRecipe
                };

                var testCookbook2 = new Cookbook
                {
                    User = testUser,
                    Recipe = testRecipe
                };

                await _unitOfWork.Cookbooks.Add(testCookbook);
                await _unitOfWork.Cookbooks.Add(testCookbook2);
                await _unitOfWork.Complete();

                var tempTestCookbooks = await _unitOfWork.Cookbooks.GetByUserEager(1);
                testResultsCookbooks = tempTestCookbooks.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal(1, testResultsCookbooks[0].User.Id);
                Assert.Equal("TestPass", testResultsCookbooks[0].User.Password);
                Assert.Equal(1, testResultsCookbooks[1].User.Id);
                Assert.Equal("TestPass", testResultsCookbooks[1].User.Password);
            }
        }

        /// <summary>
        /// Test 8 -- 
        /// Uses the User repository to delete an entity from the database.
        /// </summary>
        [Fact]
        public async void TestUserDelete()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test8DB")
                .Options;

            //Act
            List<User> userElements;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                await _unitOfWork.Users.Add(testUser);
                await _unitOfWork.Complete();

                await _unitOfWork.Users.Delete(1);
                await _unitOfWork.Complete();

                var tempTestUsers = await _unitOfWork.Users.GetAll();
                userElements = tempTestUsers.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Empty(userElements);
            }
        }

        /// <summary>
        /// Test 9 -- 
        /// Uses the Review repository to delete an entity from the database.
        /// </summary>
        [Fact]
        public async void TestReviewDelete()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test9DB")
                .Options;

            //Act
            List<RecipeReview> reviewElements;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testReview = new RecipeReview
                {

                };

                await _unitOfWork.RecipeReviews.Add(testReview);
                await _unitOfWork.Complete();

                await _unitOfWork.RecipeReviews.Delete(1);
                await _unitOfWork.Complete();

                var tempTestReviews = await _unitOfWork.RecipeReviews.GetAll();
                reviewElements = tempTestReviews.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Empty(reviewElements);
            }
        }

        /// <summary>
        /// Test 10 -- 
        /// Uses the Review repository to eager load an entity from the database.
        /// </summary>
        [Fact]
        public async void TestReviewGetEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test10DB")
                .Options;

            //Act
            RecipeReview testResultReview;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5,
                    RecipeInstruction = "Do the thing"
                };

                var testReview = new RecipeReview
                {
                    Recipe = testRecipe,
                    User = testUser
                };

                //await _unitOfWork.Recipes.Add(testRecipe);
                await _unitOfWork.RecipeReviews.Add(testReview);
                await _unitOfWork.Complete();

                var tempTestReview = await _unitOfWork.RecipeReviews.GetEager(1);
                testResultReview = tempTestReview;
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal(5, testResultReview.Recipe.RecipeCookTime);
            }
        }

        /// <summary>
        /// Test 11 -- 
        /// Uses the Review repository to eager load all entities from the database based on a Recipe ID.
        /// </summary>
        [Fact]
        public async void TestReviewGetByRecipeEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test11DB")
                .Options;

            //Act
            List<RecipeReview> testResultsRecipeReviews;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5
                };

                var testReview = new RecipeReview
                {
                    Recipe = testRecipe,
                    User = testUser
                };

                var testReview2 = new RecipeReview
                {
                    Recipe = testRecipe,
                    User = testUser
                };

                await _unitOfWork.RecipeReviews.Add(testReview);
                await _unitOfWork.RecipeReviews.Add(testReview2);
                await _unitOfWork.Complete();

                var tempTestRecipeReviews = await _unitOfWork.RecipeReviews.GetByRecipeEager(1);
                testResultsRecipeReviews = tempTestRecipeReviews.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal(1, testResultsRecipeReviews[0].Recipe.Id);
                Assert.Equal(5, testResultsRecipeReviews[0].Recipe.RecipeCookTime);
                Assert.Equal(1, testResultsRecipeReviews[1].Recipe.Id);
                Assert.Equal(5, testResultsRecipeReviews[1].Recipe.RecipeCookTime);
            }
        }

        /// <summary>
        /// Test 12 -- 
        /// Uses the Recipe repository to delete an entity from the database.
        /// </summary>
        [Fact]
        public async void TestRecipeDelete()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test12DB")
                .Options;

            //Act
            List<Recipe> recipeElements;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testRecipe = new Recipe
                {

                };

                await _unitOfWork.Recipes.Add(testRecipe);
                await _unitOfWork.Complete();

                await _unitOfWork.Recipes.Delete(1);
                await _unitOfWork.Complete();

                var tempTestRecipes = await _unitOfWork.Recipes.GetAll();
                recipeElements = tempTestRecipes.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Empty(recipeElements);
            }
        }

        /// <summary>
        /// Test 13 -- 
        /// Uses the Recipe repository to eager load an entity from the database.
        /// </summary>
        [Fact]
        public async void TestRecipeGetEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test13DB")
                .Options;

            //Act
            Recipe testResultRecipe;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5,
                    User = testUser
                };

                await _unitOfWork.Recipes.Add(testRecipe);
                await _unitOfWork.Complete();

                var tempTestRecipe = await _unitOfWork.Recipes.GetEager(1);
                testResultRecipe = tempTestRecipe;
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal("TestUser", testResultRecipe.User.Username);
            }
        }

        /// <summary>
        /// Test 14 -- 
        /// Uses the Recipe repository to eager load all entities from the database.
        /// </summary>
        [Fact]
        public async void TestRecipeGetAllEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test14DB")
                .Options;

            //Act
            List<Recipe> testResultsRecipes;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testUser2 = new User
                {
                    Username = "TestUser2",
                    Password = "TestPass2",
                    Email = "Test2@Test.Test"
                };

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5,
                    User = testUser
                };

                var testRecipe2 = new Recipe
                {
                    RecipeCookTime = 5,
                    User = testUser2
                };

                await _unitOfWork.Recipes.Add(testRecipe);
                await _unitOfWork.Recipes.Add(testRecipe2);
                await _unitOfWork.Complete();

                var tempTestRecipes = await _unitOfWork.Recipes.GetAllEager();
                testResultsRecipes = tempTestRecipes.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal(1, testResultsRecipes[0].User.Id);
                Assert.Equal("TestUser", testResultsRecipes[0].User.Username);
                Assert.Equal(2, testResultsRecipes[1].User.Id);
                Assert.Equal("TestUser2", testResultsRecipes[1].User.Username);
            }
        }

        /// <summary>
        /// Test 15 -- 
        /// Uses the RecipeIngredientGroup repository to delete an entity from the database.
        /// </summary>
        [Fact]
        public async void TestRIGDelete()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test15DB")
                .Options;

            //Act
            List<RecipeIngredientGroups> rigElements;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testRIG = new RecipeIngredientGroups
                {

                };

                await _unitOfWork.RecipeIngredientGroups.Add(testRIG);
                await _unitOfWork.Complete();

                _unitOfWork.RecipeIngredientGroups.Delete(1);
                await _unitOfWork.Complete();

                var tempTestRIG = await _unitOfWork.RecipeIngredientGroups.GetAll();
                rigElements = tempTestRIG.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Empty(rigElements);
            }
        }

        /// <summary>
        /// Test 16 -- 
        /// Uses the RecipeIngredientGroup repository to delete an entity from the database.
        /// </summary>
        [Fact]
        public async void TestRIGDeleteAll()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test16DB")
                .Options;

            //Act
            List<RecipeIngredientGroups> rigElements;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testRecipe = new Recipe
                {

                };

                var testRIG = new RecipeIngredientGroups
                {
                    Recipe = testRecipe
                };

                var testRIG2 = new RecipeIngredientGroups
                {
                    Recipe = testRecipe
                };

                await _unitOfWork.RecipeIngredientGroups.Add(testRIG);
                await _unitOfWork.RecipeIngredientGroups.Add(testRIG2);
                await _unitOfWork.Complete();

                await _unitOfWork.RecipeIngredientGroups.DeleteAll(1);
                await _unitOfWork.Complete();

                var tempTestRIG = await _unitOfWork.RecipeIngredientGroups.GetAll();
                rigElements = tempTestRIG.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Empty(rigElements);
            }
        }

        /// <summary>
        /// Test 17 -- 
        /// Uses the RecipeIngredientGroup repository to eager load an entity from the database.
        /// </summary>
        [Fact]
        public async void TestRIGGetEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test17DB")
                .Options;

            //Act
            RecipeIngredientGroups testResultRIG;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "America"
                };

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5,
                    User = testUser,
                    RecipeOrigin = testOrigin
                };

                var testIngredient = new RecipeIngredient
                {
                    RecipeIngredientName = "TestIngredient"
                };

                var testMeasurement = new RecipeMeasurement
                {
                    RecipeMeasurementName = "TestMeasurement"
                };

                var testRIG = new RecipeIngredientGroups
                {
                    Recipe = testRecipe,
                    RecipeIngredient = testIngredient,
                    RecipeMeasurement = testMeasurement,
                    RecipeIngredientAmount = 5
                };

                //await _unitOfWork.Recipes.Add(testRecipe);
                await _unitOfWork.RecipeIngredientGroups.Add(testRIG);
                await _unitOfWork.Complete();

                var tempTestRIG = await _unitOfWork.RecipeIngredientGroups.GetEager(1);
                testResultRIG = tempTestRIG;
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal(1, testResultRIG.Recipe.Id);
                Assert.Equal(5, testResultRIG.Recipe.RecipeCookTime);
            }
        }

        /// <summary>
        /// Test 18 -- 
        /// Uses the RecipeIngredientGroup repository to eager load all entities from the database, using a Recipe ID.
        /// </summary>
        [Fact]
        public async void TestRIGGetByRecipeEager()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test18DB")
                .Options;

            //Act
            List<RecipeIngredientGroups> testResultsRecipeIngredientGroups;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testUser = new User
                {
                    Username = "TestUser",
                    Password = "TestPass",
                    Email = "Test@Test.Test"
                };

                var testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "America"
                };

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5,
                    User = testUser,
                    RecipeOrigin = testOrigin
                };

                var testIngredient = new RecipeIngredient
                {
                    RecipeIngredientName = "TestIngredient"
                };

                var testMeasurement = new RecipeMeasurement
                {
                    RecipeMeasurementName = "TestMeasurement"
                };

                var testRIG = new RecipeIngredientGroups
                {
                    Recipe = testRecipe,
                    RecipeIngredient = testIngredient,
                    RecipeMeasurement = testMeasurement,
                    RecipeIngredientAmount = 5
                };

                var testRIG2 = new RecipeIngredientGroups
                {
                    Recipe = testRecipe,
                    RecipeIngredient = testIngredient,
                    RecipeMeasurement = testMeasurement,
                    RecipeIngredientAmount = 5
                };

                await _unitOfWork.RecipeIngredientGroups.Add(testRIG);
                await _unitOfWork.RecipeIngredientGroups.Add(testRIG2);
                await _unitOfWork.Complete();

                var tempTestRecipeIngredientGroups = await _unitOfWork.RecipeIngredientGroups.GetByRecipeEager(1);
                testResultsRecipeIngredientGroups = tempTestRecipeIngredientGroups.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.Equal(1, testResultsRecipeIngredientGroups[0].Recipe.Id);
                Assert.Equal(5, testResultsRecipeIngredientGroups[0].Recipe.RecipeCookTime);
                Assert.Equal(1, testResultsRecipeIngredientGroups[1].Recipe.Id);
                Assert.Equal(5, testResultsRecipeIngredientGroups[1].Recipe.RecipeCookTime);
            }
        }

        /// <summary>
        /// Test 19 -- 
        /// Uses the RecipeIngredientGroup repository to eager load all entities from the database.
        /// </summary>
        [Fact]
        public async void TestRIGAddRange()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test19DB")
                .Options;

            //Act
            List<RecipeIngredientGroups> testRIGEntries = new List<RecipeIngredientGroups>();
            List<RecipeIngredientGroups> testResultsRIG;
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);

                var testRecipe = new Recipe
                {
                    RecipeCookTime = 5
                };

                var testRIG = new RecipeIngredientGroups
                {
                    Recipe = testRecipe
                };

                var testRIG2 = new RecipeIngredientGroups
                {
                    Recipe = testRecipe
                };

                testRIGEntries.Add(testRIG);
                testRIGEntries.Add(testRIG2);

                _unitOfWork.RecipeIngredientGroups.AddRange(testRIGEntries);
                await _unitOfWork.Complete();

                var tempTestRecipeIngredientGroups = await _unitOfWork.RecipeIngredientGroups.GetAll();
                testResultsRIG = tempTestRecipeIngredientGroups.ToList();
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                Assert.NotEmpty(testResultsRIG);
                Assert.Equal(1, testResultsRIG[0].Recipe.Id);
                Assert.Equal(5, testResultsRIG[0].Recipe.RecipeCookTime);
                Assert.Equal(1, testResultsRIG[1].Recipe.Id);
                Assert.Equal(5, testResultsRIG[1].Recipe.RecipeCookTime);
            }
        }

        /// <summary>
        /// Test 20 -- 
        /// Uses the BusinessL layer to post a cookbook to the database.
        /// </summary>
        [Fact]
        public async void TestBLPostCookbook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test20DB")
                .Options;
            Cookbook testResult;
            //Act
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);
                var businessLogic = new BusinessL(_unitOfWork, null);

                var testUser = new User
                {
                    Email = "e@e.e",
                    Username = "testUser",
                    Password = "testPass"
                };
                await _unitOfWork.Users.Add(testUser);

                var testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "test"
                };
                await _unitOfWork.RecipeOrigins.Add(testOrigin);

                var testRecipe = new Recipe
                {
                    RecipeOrigin = testOrigin,
                    User = testUser
                };
                await _unitOfWork.Recipes.Add(testRecipe);
                await _unitOfWork.Complete();

                var testCookbookVM = new PostCookbookVM
                {
                    RecipeId = 1,
                    UserId = 1
                };

                await businessLogic.PostCookbook(testCookbookVM);

                testResult = await _unitOfWork.Cookbooks.GetEager(1);
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);
                Assert.Equal(1, testResult.Id);
                Assert.Equal(1, testResult.Recipe.Id);
                Assert.Equal(1, testResult.User.Id);
            }
            
        }

        /// <summary>
        /// Test 21 -- 
        /// Uses the BusinessL layer to post a cookbook to the database.
        /// </summary>
        [Fact]
        public async void TestBLGetCookbook()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<CookingpapaContext>()
                .UseInMemoryDatabase(databaseName: "Test20DB")
                .Options;
            List<GetCookbookVM> testResult = new List<GetCookbookVM>();
            //Act
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);
                var businessLogic = new BusinessL(_unitOfWork, null);

                var testUser = new User
                {
                    Email = "e@e.e",
                    Username = "testUser",
                    Password = "testPass"
                };
                await _unitOfWork.Users.Add(testUser);

                var testOrigin = new RecipeOrigin
                {
                    RecipeOriginName = "test"
                };
                await _unitOfWork.RecipeOrigins.Add(testOrigin);

                var testRecipe = new Recipe
                {
                    RecipeOrigin = testOrigin,
                    User = testUser,
                    RecipeName = "testName",
                    RecipeCookTime = 5
                };
                await _unitOfWork.Recipes.Add(testRecipe);
                

                var testCookbook = new Cookbook
                {
                    Recipe = testRecipe,
                    User = testUser
                };
                await _unitOfWork.Cookbooks.Add(testCookbook);
                await _unitOfWork.Complete();

                testResult = await businessLogic.GetCookbook(1);
            }

            //Assert
            using (var context = new CookingpapaContext(options))
            {
                var _unitOfWork = new UnitOfWork(context);
                Assert.Equal(1, testResult[0].CookbookId);
                Assert.Equal(1, testResult[0].RecipeId);
                Assert.Equal(1, testResult[0].UserId);
                Assert.Equal("test", testResult[0].RecipeOrigin);
                Assert.Equal("testName", testResult[0].RecipeName);
                Assert.Equal(5, testResult[0].RecipeCookTime);
            }

        }
    }
}