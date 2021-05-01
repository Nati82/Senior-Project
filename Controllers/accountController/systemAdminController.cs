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
    public class systemAdminController : ControllerBase
    {
        serviceHandler sh;
        systemAdminHandler sah;
        authenticateHandler ah;
        private readonly IAuthenticate authenticate;
        private readonly IServiceRepository serviceRepository;
        private readonly ISysAdminRepository sysAdminRepository;
        private readonly IGarageRepository garageRepository;
        private readonly ILogtimeRepository logtimeRepository;

        public systemAdminController(
            IAuthenticate authenticate, 
            IServiceRepository serviceRepository, 
            ISysAdminRepository sysAdminRepository, 
            IGarageRepository garageRepository,
            ILogtimeRepository logtimeRepository)
        {
            this.authenticate = authenticate;
            this.sysAdminRepository = sysAdminRepository;
            this.serviceRepository = serviceRepository;
            this.garageRepository = garageRepository;
            this.logtimeRepository = logtimeRepository;

            ah = new authenticateHandler(this.authenticate, this.logtimeRepository);
            sh = new serviceHandler(this.serviceRepository, this.garageRepository);
            sah = new systemAdminHandler(this.sysAdminRepository);
        }

        [AllowAnonymous]
        [HttpGet("{username}")]
        public IActionResult get(string username) => Ok(sah.Get(username));

        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult signUp([FromBody] SystemAdmin systemAdmin)
        {
                return Ok(sah.signUp(systemAdmin));
        }

        [HttpPatch("ChangePassword")]
        public IActionResult changePassword([FromBody] tempService systemAdmin)
        {
            if (sah.changePassWord(systemAdmin))
                return Ok(sah.Get(systemAdmin.username));
            else
                return Ok(false);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] SystemAdmin systemAdmin)
        {
            var token = authenticate.Login(systemAdmin.username, systemAdmin.password);
            var returnedSysAdmin = sah.Get(systemAdmin.username);
            returnedSysAdmin.password = null;
            returnedSysAdmin.token = token;

            if (token == null) return Unauthorized();

            return Ok(returnedSysAdmin);
        }

        [HttpPost("Logout")]
        public IActionResult Logout() => Ok(authenticate.Logout());

    }
}