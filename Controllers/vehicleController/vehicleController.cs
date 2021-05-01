using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senior_Project.Handlers.vehicleHandler;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IServices;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Vehicles;

namespace Senior_Project.Controllers.vehicleController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class vehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly ICustomerRepository customerRepository;
        vehicleHandler vh;

        public vehicleController(ICustomerRepository customerRepository, IVehicleRepository vehicleRepository)
        {
            this.customerRepository = customerRepository;
            this.vehicleRepository = vehicleRepository;
            vh = new vehicleHandler(this.customerRepository, this.vehicleRepository);
        }

        [HttpGet]
        public IActionResult viewVehicles() => Ok(vh.viewVehicle());

        [HttpGet("{customerId}")]
        public IActionResult viewVehicles(int CustomerId) => Ok(vh.viewVehicle(CustomerId));

        [HttpPost]
        public IActionResult registerVehicle([FromBody] Vehicle vehicle)
        {
            if (vh.add(vehicle))
                return Ok(vh.viewVehicle(vehicle.customerId));
            else
                return Ok(false);
        }
        
    }
}