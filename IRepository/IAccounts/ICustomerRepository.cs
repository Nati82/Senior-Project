using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> customers { get; }
        public bool Add(Customer customer);
        public bool Update(Customer customer);
    }
}
