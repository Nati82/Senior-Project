using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IAccounts
{
    public interface IGarageRepository
    {
        IEnumerable<Garage> garages { get; }
        public bool Add(Garage garage);
        public bool Update(Garage garage);
    }
}
