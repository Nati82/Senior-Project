using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface IAuthenticate
    {
        public string Login(string username, string password);
        public bool Logout();
    }
}
