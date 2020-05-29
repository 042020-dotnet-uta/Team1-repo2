using CookingPapa.Domain.Models;
using CookingPapa.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa.Domain.Business
{
    public interface IBusinessL
    {
        Task<Cookbook> PostCookbook(PostCookbookVM cookbook);
        Task<List<GetCookbookVM>> GetCookbook(int id);
    }
}
