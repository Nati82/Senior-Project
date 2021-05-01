using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senior_Project.Handlers.accountHandler;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Controllers.accountController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class applicationController : ControllerBase
    {
        private readonly IApplicationRepository applicationRepository;
        private readonly IMechanicRepository mechanicRepository;
        private readonly IGarageRepository garageRepository;
        private readonly ILocationRepository locationRepository;
        applicationHandler ah;

        public applicationController(IApplicationRepository applicationRepository, IMechanicRepository mechanicRepository, IGarageRepository garageRepository, ILocationRepository locationRepository)
        {
            this.applicationRepository = applicationRepository;
            this.mechanicRepository = mechanicRepository;
            this.garageRepository = garageRepository;
            this.locationRepository = locationRepository;

            ah = new applicationHandler(this.applicationRepository, this.mechanicRepository, this.garageRepository, this.locationRepository);
        }

        [HttpGet("applications")]
        public IActionResult get()
        {
             return Ok(ah.Get());
        }

        [HttpPost("approvemech")]
        public IActionResult approveMechanic(Application application)
        {
            if (ah.approveMechanic(application))
                return Ok(ah.Get());
            else
                return Ok(false);
        }

        [HttpPost("approvegar")]
        public IActionResult approveGarage(Application application)
        {
            if (ah.approveGarage(application))
                return Ok(ah.Get());
            else
                return Ok(false);
        }
    }
}