using System;
using System.Collections.Generic;
using System.Text;
using CookingPapa.Data.Repositories;
using CookingPapa.Domain;
using CookingPapa.Domain.Models;
using CookingPapa.Domain.RepositoryInterfaces;

namespace CookingPapa.Data
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly CookingpapaContext _context;
        public UnitOfWork(CookingpapaContext context)
        {
            _context = context;
            Cookbooks = new Repository<Cookbook>(_context);
            Recipes = new Repository<Recipe>(_context);
            RecipeIngredients = new Repository<RecipeIngredient>(_context);
            RecipeIngredientGroups = new Repository<RecipeIngredientGroups>(_context);
            RecipeMeasurements = new Repository<RecipeMeasurement>(_context);
            RecipeOrigins = new Repository<RecipeOrigin>(_context);
            RecipeReviews = new Repository<RecipeReview>(_context);
            Users = new Repository<User>(_context);
        }

        #region Repository Constructors
        public IRepository<Cookbook> Cookbooks { get; private set; }

        public IRepository<Recipe> Recipes { get; private set; }

        public IRepository<RecipeIngredient> RecipeIngredients { get; private set; }

        public IRepository<RecipeIngredientGroups> RecipeIngredientGroups { get; private set; }

        public IRepository<RecipeMeasurement> RecipeMeasurements { get; private set; }

        public IRepository<RecipeOrigin> RecipeOrigins { get; private set; }

        public IRepository<RecipeReview> RecipeReviews { get; private set; }

        public IRepository<User> Users { get; private set; }
        #endregion

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
