using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Repositories.Accounts
{
    public class garageRepository : IGarageRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Garage> garages => context.Garages;
        public bool Add(Garage garage)
        {
            context.Garages.Add(garage);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Garage garage)
        {
            context.Garages.Update(garage);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
