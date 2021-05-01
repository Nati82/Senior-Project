using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;

namespace Senior_Project.Repositories.Accounts
{
    public class customerRepository : ICustomerRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Customer> customers => context.Customers;
        
        public bool Add(Customer customer)
        {
            context.Customers.Add(customer);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Customer customer)
        {
            context.Customers.Update(customer);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
