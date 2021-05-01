using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface ISysAdminRepository
    {
        IEnumerable<SystemAdmin> systemAdmins { get; }
        public bool Add(SystemAdmin systemAdmin);
        public bool Update(SystemAdmin systemAdmin);
    }
}
