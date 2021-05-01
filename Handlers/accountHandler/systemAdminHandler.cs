using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;
using Senior_Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.accountHandler
{
    public class systemAdminHandler
    {
        ISysAdminRepository sysAdminRepository;
        public systemAdminHandler(ISysAdminRepository sysAdminRepository)
        {
            this.sysAdminRepository = sysAdminRepository;
        }


        public bool signUp(SystemAdmin systemAdmin)
        {
            if (!sysAdminRepository.systemAdmins.Any(s => s.username == systemAdmin.username))
                return sysAdminRepository.Add(systemAdmin);
            else
                return false;
        }

        public bool changePassWord(tempService sysAdmin)
        {
            var sys = Get(sysAdmin.username);
            if (sys.password == sysAdmin.oldpassword)
                sys.password = sysAdmin.newpassword;
            else return false;

            return sysAdminRepository.Update(sys);
        }

        public SystemAdmin Get(string username)
        {
            return sysAdminRepository.systemAdmins.Where(s => s.username == username).FirstOrDefault();
        }
    }
}
