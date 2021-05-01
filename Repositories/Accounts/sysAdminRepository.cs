using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Repositories.Accounts
{
    public class sysAdminRepository : ISysAdminRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<SystemAdmin> systemAdmins => context.SystemAdmin;
        public bool Add(SystemAdmin systemAdmin)
        {
            context.SystemAdmin.Add(systemAdmin);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(SystemAdmin systemAdmin)
        {
            context.SystemAdmin.Update(systemAdmin);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
