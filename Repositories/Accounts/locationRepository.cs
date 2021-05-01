using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Repositories.Accounts
{
    public class locationRepository : ILocationRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Location> locations => context.Locations;
        public bool Add(Location location)
        {
            context.Locations.Add(location);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Location location)
        {
            context.Locations.Update(location);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
