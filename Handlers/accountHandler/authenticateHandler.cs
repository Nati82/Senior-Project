using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.accountHandler
{
    public class authenticateHandler
    {
        IAuthenticate authenticate;
        ILogtimeRepository logtimeRepository;
        

        public authenticateHandler(IAuthenticate authenticate, ILogtimeRepository logtimeRepository)
        {
            this.authenticate = authenticate;
            this.logtimeRepository = logtimeRepository;
        }

        public string Login(string username, string password, string userRole)
        {
            LogTime logTime = new LogTime();
            logTime.username = username;
            logTime.userRole = userRole;
            logTime.loginTime = DateTime.UtcNow;
            logtimeRepository.Add(logTime);
            return authenticate.Login(username, password);
        }

        public bool Logout()
        {

            return authenticate.Logout();
        }
    }
}
