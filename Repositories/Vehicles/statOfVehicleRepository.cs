using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Vehicles;

namespace Senior_Project.Repositories.Vehicles
{
    public class statOfVehicleRepository : IStatOfVehicleRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<statusOfVehicle> statusOfVehicles => context.statusOfVehicles;
        public bool Add(statusOfVehicle statusOfVehicle)
        {
            context.statusOfVehicles.Add(statusOfVehicle);
            return context.SaveChanges()!=0 ? true : false;
        }
        public bool Update(statusOfVehicle statusOfVehicle)
        {
            context.statusOfVehicles.Update(statusOfVehicle);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
