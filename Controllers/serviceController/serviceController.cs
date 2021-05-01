using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Senior_Project.Handlers.serviceHandler;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IServices;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;
using Senior_Project.Models.Services;

namespace Senior_Project.Controllers.serviceController
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class serviceController : ControllerBase
    {
        private readonly IServiceRepository serviceRepository;
        private readonly IGarageRepository garageRepository;
        serviceHandler sh;

        public serviceController(IServiceRepository serviceRepository, IGarageRepository garageRepository)
        {
            this.serviceRepository = serviceRepository;
            this.garageRepository = garageRepository;
            sh = new serviceHandler(this.serviceRepository, this.garageRepository);
        }
        [HttpGet]
        public IActionResult viewService()
            => Ok(sh.viewServiceAdmin());

        [HttpGet("{garageId}")]
        public IActionResult viewService(int garageId)
            => Ok(sh.viewServiceGar(garageId));

        [HttpPost("create")]
        public IActionResult createService([FromBody] Service service)
        {
            if (sh.createService(service))
                return Ok(sh.viewServiceAdmin());
            else
                return Ok(false);
        }
        [HttpPost("add")]
        public IActionResult addServiceGarage([FromBody] tempService createService)
        {
            if (sh.addServiceGarage(createService.service, createService.garage))
                return Ok(sh.viewService(createService.garage.username));
            else
                return Ok(false);
        }




        [HttpPatch("update")]
        public bool updateService([FromBody] Service service)
            => sh.updateServiceGarage(service);

        [HttpPatch("removead/{serviceId}")]
        public bool removeService(int serviceId)
            => sh.removeServiceAdmin(serviceId);

        [HttpPatch("removegar")]
        public bool removeService([FromBody] tempService updateService)
            => sh.removeServiceGarage(updateService.serviceId, updateService.garageId);

    }
}