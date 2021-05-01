using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senior_Project.Handlers.vehicleHandler;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Vehicles;

namespace Senior_Project.Controllers.vehicleController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class statOfVehicleController : ControllerBase
    {
        statOfVehicleHandler sov;
        private readonly ICustomerRepository customerRepository;
        private readonly IMechanicRepository mechanicRepository;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IStatOfVehicleRepository StatOfVehicleRepository;

        public statOfVehicleController(
            ICustomerRepository customerRepository, 
            IMechanicRepository mechanicRepository, 
            IVehicleRepository vehicleRepository, 
            IStatOfVehicleRepository StatOfVehicleRepository)
        {
            this.customerRepository = customerRepository;
            this.mechanicRepository = mechanicRepository;
            this.vehicleRepository = vehicleRepository;
            this.StatOfVehicleRepository = StatOfVehicleRepository;
            sov = new statOfVehicleHandler(this.customerRepository, this.mechanicRepository, this.StatOfVehicleRepository, this.vehicleRepository);
        }
        [HttpPost]
        public IActionResult addStat([FromBody] statusOfVehicle stat)
        {
            if (sov.createStatus(stat))
                return Ok(sov.viewStatus(stat.Id));
            else
                return Ok(false);
        }

        [HttpPatch]
        public IActionResult approveStat([FromBody] statusOfVehicle stat)
        {
            if (sov.approveStatus(stat))
                return Ok(sov.viewStatus());
            else
                return Ok(false);
        }

        [HttpGet]
        public IActionResult getStatus() => Ok(sov.viewStatus());

        [HttpGet("{custId}")]
        public IActionResult getStatus(int custId) => Ok(sov.viewStatusCustomer(custId));
    }
}