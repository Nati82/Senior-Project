using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Repositories.Accounts
{
    public class applicationRepository : IApplicationRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Application> applications => context.Applications;
        public bool Add(Application application)
        {
            context.Applications.Add(application);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Application application)
        {
            context.Applications.Update(application);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
