using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Vehicles;

namespace Senior_Project.Repositories.Vehicles
{
    public class vehicleRepository : IVehicleRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Vehicle> vehicles => context.Vehicles;
        public bool Add(Vehicle vehicle)
        {
            context.Vehicles.Add(vehicle);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Vehicle vehicle)
        {
            context.Vehicles.Update(vehicle);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
