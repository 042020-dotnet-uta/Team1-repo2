using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Data.Repositories;
using CookingPapa.Domain;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;
using System.Threading.Tasks;

namespace CookingPapa.Data
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly CookingpapaContext _context;
        public UnitOfWork(CookingpapaContext context)
        {
            _context = context;
            Cookbooks = new CookbookRepository(_context);
            Recipes = new RecipeRepository(_context);
            RecipeIngredients = new Repository<RecipeIngredient>(_context);
            RecipeIngredientGroups = new RecipeIngredientGroupRepository(_context);
            RecipeMeasurements = new Repository<RecipeMeasurement>(_context);
            RecipeOrigins = new Repository<RecipeOrigin>(_context);
            RecipeReviews = new ReviewRepository(_context);
            Users = new Repository<User>(_context);
        }

        #region Repository Constructors
        public ICookbookRepository Cookbooks { get; private set; }

        public IRecipeRepository Recipes { get; private set; }

        public IRepository<RecipeIngredient> RecipeIngredients { get; private set; }

        public IRecipeIngredientGroupRepository RecipeIngredientGroups { get; private set; }

        public IRepository<RecipeMeasurement> RecipeMeasurements { get; private set; }

        public IRepository<RecipeOrigin> RecipeOrigins { get; private set; }

        public IReviewRepository RecipeReviews { get; private set; }

        public IRepository<User> Users { get; private set; }
        #endregion

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
