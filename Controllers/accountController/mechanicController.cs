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
using Senior_Project.Repositories.Accounts;

namespace Senior_Project.Controllers.accountController
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class mechanicController : ControllerBase
    {
        serviceHandler sh;
        MechanicHandler mh;
        authenticateHandler ah;
        private readonly IServiceRepository serviceRepository;
        private readonly IMechanicRepository mechanicRepository;
        private readonly IAuthenticate authenticate;
        private readonly IGarageRepository garageRepository;
        private readonly IApplicationRepository applicationRepository;
        private readonly ILogtimeRepository logtimeRepository;

        public mechanicController(
            IApplicationRepository applicationRepository, 
            IAuthenticate authenticate, 
            IServiceRepository serviceRepository, 
            IMechanicRepository mechanicRepository, 
            IGarageRepository garageRepository,
            ILogtimeRepository logtimeRepository)
        {
            this.authenticate = authenticate;
            this.mechanicRepository = mechanicRepository;
            this.serviceRepository = serviceRepository;
            this.applicationRepository = applicationRepository;
            this.garageRepository = garageRepository;
            this.logtimeRepository = logtimeRepository;

            ah = new authenticateHandler(this.authenticate, this.logtimeRepository);
            sh = new serviceHandler(this.serviceRepository, this.garageRepository);
            mh = new MechanicHandler(this.mechanicRepository, this.garageRepository, this.applicationRepository);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult get() => Ok(mh.Get());

        [AllowAnonymous]
        [HttpGet("{username}")]
        public IActionResult get(string username) => Ok(mh.Get(username));

        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult signUp([FromBody] Application mechanic)
        {
                return Ok(mh.signUp(mechanic));
        }

        [HttpPatch("ChangePassword")]
        public IActionResult changePassword([FromBody] tempService mechanic)
        {
            if (mh.changePassWord(mechanic))
                return Ok(mh.Get(mechanic.username));
            else
                return Ok(false);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Mechanic mechanic)
        {
            var token = authenticate.Login(mechanic.username, mechanic.password);
            var returnedMechanic = mh.Get(mechanic.username);
            returnedMechanic.password = null;
            returnedMechanic.token = token;

            if (token == null) return Unauthorized();

            return Ok(returnedMechanic);
        }

        [HttpPost("Logout")]
        public IActionResult Logout() => Ok(authenticate.Logout());
    }

}
