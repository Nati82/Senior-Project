using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> applications { get; }
        public bool Add(Application application);
        public bool Update(Application application);
    }
}
