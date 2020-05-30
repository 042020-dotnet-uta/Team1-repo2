using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookingPapa.Domain;
using CookingPapa.Domain.Business;
using CookingPapa.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CookingPapa.Api.Controllers
{
    [Route("api/Information")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        //This part should be changed to the repository or business logic 
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RecipesController> _logger;
        private readonly IBusinessL _businessL;

        public InformationController(IUnitOfWork unitOfWork, ILogger<RecipesController> logger,
            IBusinessL businessL)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _businessL = businessL;
        }

        [HttpGet]
        public async Task<ActionResult<InformationVM>> GetInformation()
        {
            var information = await _businessL.GetInformation();
            return information;
        }

    }
}
