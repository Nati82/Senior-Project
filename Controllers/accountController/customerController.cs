using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senior_Project.DataBase;
using Senior_Project.Handlers.accountHandler;
using Senior_Project.Handlers.serviceHandler;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IServices;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;

namespace Senior_Project.Controllers.accountController
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class customerController : ControllerBase
    {
        serviceHandler sh;
        CustomerHandler ch;
        authenticateHandler ah;
        private readonly IServiceRepository serviceRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IGarageRepository garageRepository;
        private readonly IAuthenticate authenticate;
        private readonly ILogtimeRepository logtimeRepository;

        public customerController(
            IAuthenticate authenticate, 
            IGarageRepository garageRepository, 
            IServiceRepository serviceRepository, 
            ICustomerRepository customerRepository,
            ILogtimeRepository logtimeRepository)
        {
            this.authenticate = authenticate;
            this.customerRepository = customerRepository;
            this.serviceRepository = serviceRepository;
            this.garageRepository = garageRepository;
            this.logtimeRepository = logtimeRepository;

            ah = new authenticateHandler(this.authenticate, this.logtimeRepository);
            sh = new serviceHandler(this.serviceRepository, this.garageRepository);
            ch = new CustomerHandler(this.customerRepository);
        }

        [HttpGet]
        public IActionResult get() => Ok(ch.Get());

        [AllowAnonymous]
        [HttpGet("{username}")]
        public IActionResult get(string username) => Ok(ch.Get(username));

        [AllowAnonymous]
        [HttpPost("Signup")]
        public IActionResult signUp([FromBody] Customer customer)
        {
                return Ok(ch.signUp(customer));
        }

        [HttpPatch("ChangePassword")]
        public IActionResult changePassword([FromBody] tempService customer)
        {
            if (ch.changePassWord(customer))
                return Ok(ch.Get(customer.username));
            else
                return Ok(false);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Customer customer)
        {
            var token = ah.Login(customer.username, customer.password, typeof(Customer).ToString());
            var returnedCustomer = ch.Get(customer.username);
            returnedCustomer.password = null;
            returnedCustomer.token = token;

            if (token == null) return Unauthorized();

            return Ok(returnedCustomer);
        }

        [HttpPost("Logout")]
        public IActionResult Logout() => Ok(ah.Logout());
    }
}