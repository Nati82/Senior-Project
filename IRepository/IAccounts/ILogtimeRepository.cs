using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface ILogtimeRepository
    {
        IEnumerable<LogTime> logTimes { get; }
        public bool Add(LogTime logtime);
        public bool Update(LogTime logTime);
    }
}
