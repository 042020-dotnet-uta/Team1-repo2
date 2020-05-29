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
    /// <summary>
    /// The Unit of Work serves as the bridge between data access and business logic.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Container for the DbContext.
        /// </summary>
        private readonly CookingpapaContext _context;
        /// <summary>
        /// Constructors for the various repositories held by the Unit of Work, built from the same DbContext.
        /// </summary>
        /// <param name="context">The DbContext to be used when creating the repositories.</param>
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

        #region Repository Containers
        public ICookbookRepository Cookbooks { get; private set; }

        public IRecipeRepository Recipes { get; private set; }

        public IRepository<RecipeIngredient> RecipeIngredients { get; private set; }

        public IRecipeIngredientGroupRepository RecipeIngredientGroups { get; private set; }

        public IRepository<RecipeMeasurement> RecipeMeasurements { get; private set; }

        public IRepository<RecipeOrigin> RecipeOrigins { get; private set; }

        public IReviewRepository RecipeReviews { get; private set; }

        public IRepository<User> Users { get; private set; }
        #endregion

        /// <summary>
        /// Saves any edits in the Unit of Work to the database.
        /// </summary>
        /// <returns>Returns integer detailing status.</returns>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Garbage collects the unit of work when finished.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
