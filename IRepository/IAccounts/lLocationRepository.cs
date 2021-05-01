using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface ILocationRepository
    {
        IEnumerable<Location> locations { get; }
        public bool Add(Location location);
        public bool Update(Location location);
    }
}
