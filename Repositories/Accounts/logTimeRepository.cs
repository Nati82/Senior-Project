using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Repositories.Accounts
{
    public class logTimeRepository:ILogtimeRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<LogTime> logTimes => context.LogTimes;
        public bool Add(LogTime logTime)
        {
            context.LogTimes.Add(logTime);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(LogTime logTime)
        {
            context.LogTimes.Update(logTime);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
