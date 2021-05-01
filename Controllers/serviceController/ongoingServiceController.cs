using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senior_Project.Handlers.serviceHandler;
using Senior_Project.IRepository.IServices;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Services;

namespace Senior_Project.Controllers.serviceController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ongoingServiceController : ControllerBase
    {
        ongoingServiceHandler ogs;
        private readonly IOnGoingServRepository onGoingServRepository;
        private readonly IStatOfVehicleRepository statOfVehicleRepository;

        public ongoingServiceController(IOnGoingServRepository onGoingServRepository, IStatOfVehicleRepository statOfVehicleRepository)
        {
            this.onGoingServRepository = onGoingServRepository;
            this.statOfVehicleRepository = statOfVehicleRepository;
            ogs = new ongoingServiceHandler(this.onGoingServRepository, this.statOfVehicleRepository);
        }

        [HttpGet("customer/{custId}")]
        public IActionResult getServicesCustomer(int custId) => Ok(ogs.viewOnGoingServCust(custId));

        [HttpGet("{mechId}")]
        public IActionResult getServicesMechanic(int mechId) => Ok(ogs.viewOnGoingServMech(mechId));

        [HttpPatch]
        public IActionResult updateServicesMechanic([FromBody] onGoingService onGoingService)
        {
            if (ogs.updateOnGoServMechanic(onGoingService))
                return Ok(ogs.viewOnGoingServ(onGoingService.statusOfVehicleId));
            else
                return Ok(false);
        }

        [HttpPost]
        public IActionResult createServiceMechanic([FromBody] onGoingService onGoingService)
        {
            if (ogs.createOnGoservMechanic(onGoingService))
                return Ok(ogs.viewOnGoingServ(onGoingService.statusOfVehicleId));
            else
                return Ok(false);
        }
    }
}