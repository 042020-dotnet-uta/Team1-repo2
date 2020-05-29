using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Business
{
    public class BusinessL:IBusinessL
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        public BusinessL(IUnitOfWork unitOfWork, ILogger<BusinessL> logger)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Cookbook> PostCookbook(PostCookbookVM cookbook)
        {
            var checkIfExists = _unitOfWork.Cookbooks.GetByUserEager(cookbook.UserId)
                             .Result.ToList().Find(x => x.Recipe.Id == cookbook.RecipeId);
            if (checkIfExists == null)
            {
                var newCookbook = new Cookbook();
                newCookbook.User = await _unitOfWork.Users.Get(cookbook.UserId);
                newCookbook.Recipe = await _unitOfWork.Recipes.GetEager(cookbook.RecipeId);
                _unitOfWork.Cookbooks.Add(newCookbook);
                await _unitOfWork.Complete();
                return newCookbook;
            }
            return null;
        }

    }
}
