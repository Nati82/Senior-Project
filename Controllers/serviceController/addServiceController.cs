using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class addServiceController : ControllerBase
    {
        private readonly IAddServRepository addServRepository;
        private readonly IStatOfVehicleRepository statOfVehicleRepository;
        addServiceHandler ash;

        public addServiceController(IAddServRepository addServRepository, IStatOfVehicleRepository statOfVehicleRepository)
        {
            this.addServRepository = addServRepository;
            this.statOfVehicleRepository = statOfVehicleRepository;
            ash = new addServiceHandler(this.addServRepository, this.statOfVehicleRepository);
        }

        [HttpPost("customer")]
        public IActionResult sendAddCustomer([FromBody] additionalService additionalService) 
            => Ok(ash.sendAddReqCustomer(additionalService));

        [HttpGet("customer/{custId}")]
        public IActionResult viewAddServCust(int custId)
            => Ok(ash.viewAddServCust(custId));

        [HttpGet("{mechId}")]
        public IActionResult viewAddServMech(int mechId)
            => Ok(ash.viewAddServMech(mechId));

        [HttpGet("stat/{statusId}")]
        public IActionResult viewServiceCustomer(int statusId) 
            => Ok(ash.viewAddService(statusId));

        [HttpPatch]
        public IActionResult updateService([FromBody] additionalService additionalService)
            => Ok(ash.updateAddService(additionalService));

        [HttpPost("mechanic")]
        public IActionResult sendAddMechanic([FromBody] additionalService additionalService) 
            => Ok(ash.sendAddReqMech(additionalService));

    }
}