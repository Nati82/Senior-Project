using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;
using Senior_Project.Repositories.Accounts;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.accountHandler
{
    public class CustomerHandler
    {
        ICustomerRepository customerRepository;
        
        public CustomerHandler(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        public bool signUp(Customer customer)
        {
            if (!customerRepository.customers.Any(c => c.username == customer.username))
                return customerRepository.Add(customer);
            else
                return false;
        }



        public bool changePassWord(tempService customer)
        {
            var cust = Get(customer.username);
            if (cust.password == customer.oldpassword)
                cust.password = customer.newpassword;
            else return false;
            
            return customerRepository.Update(cust);
        }

        public IEnumerable<Customer> Get()
           => customerRepository.customers;

        public Customer Get(string username)
           => customerRepository.customers.Where(c => c.username == username).FirstOrDefault();

    }
}
