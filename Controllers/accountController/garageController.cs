using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senior_Project.Handlers.accountHandler;
using Senior_Project.Handlers.serviceHandler;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IServices;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;

namespace Senior_Project.Controllers.accountController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class garageController : ControllerBase
    {
        serviceHandler sh;
        GarageHandler gh;
        authenticateHandler ah;
        private readonly IAuthenticate authenticate;
        private readonly IServiceRepository serviceRepository;
        private readonly IGarageRepository garageRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly ILogtimeRepository logtimeRepository;
        private readonly ILocationRepository locationRepository;

        public garageController(
            IApplicationRepository applicationRepository, 
            IAuthenticate authenticate, 
            IServiceRepository serviceRepository, 
            IGarageRepository garageRepository,
            ILogtimeRepository logtimeRepository,
            ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
            this.authenticate = authenticate;
            this.serviceRepository = serviceRepository;
            this.garageRepository = garageRepository;
            this.applicationRepository = applicationRepository;
            this.logtimeRepository = logtimeRepository;

            ah = new authenticateHandler(this.authenticate, this.logtimeRepository);
            sh = new serviceHandler(this.serviceRepository, this.garageRepository);
            gh = new GarageHandler(this.applicationRepository, this.garageRepository, this.locationRepository);
        }

        [AllowAnonymous]
        [HttpGet("{username}")]
        public IActionResult get(string username) => Ok(gh.Get(username));

        [AllowAnonymous]
        [HttpGet]
        public IActionResult get() => Ok(gh.Get());

        [AllowAnonymous]
        [HttpGet("location")]
        public IActionResult getLocation() => Ok(gh.GetLocation());

        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult signUp([FromBody] Application garage)
        {
                return Ok(gh.signUp(garage));
        }

        [HttpPatch("ChangePassword")]
        public IActionResult changePassword([FromBody] tempService garage)
        {
            if (gh.changePassWord(garage))
                return Ok(gh.Get(garage.username));
            else
                return Ok(false);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Garage garage)
        {
            var token = authenticate.Login(garage.username, garage.password);
            var returnedGarage = gh.Get(garage.username);
            returnedGarage.password = null;
            returnedGarage.token = token;

            if (token == null) return Unauthorized();
            
            return Ok(returnedGarage);
        }

        [HttpPost("Logout")]
        public IActionResult Logout() => Ok(authenticate.Logout());

    }
}