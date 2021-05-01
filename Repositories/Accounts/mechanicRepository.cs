using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Repositories.Accounts
{
    public class mechanicRepository:IMechanicRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Mechanic> mechanics => context.Mechanics;
        public bool Add(Mechanic mechanic)
        {
            context.Mechanics.Add(mechanic);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Mechanic mechanic)
        {
            context.Mechanics.Update(mechanic);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
