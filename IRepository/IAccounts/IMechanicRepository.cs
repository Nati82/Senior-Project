using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface IMechanicRepository
    {
        IEnumerable<Mechanic> mechanics { get; }
        public bool Add(Mechanic mechanic);
        public bool Update(Mechanic mechanic);
    }
}
