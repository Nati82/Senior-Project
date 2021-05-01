using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.vehicleHandler
{
    public class vehicleHandler
    {
        ICustomerRepository customer;
        IVehicleRepository vehicle;
        public vehicleHandler(ICustomerRepository customer, IVehicleRepository vehicle)
        {
            this.customer = customer;
            this.vehicle = vehicle;
        }

        public IEnumerable<Vehicle> viewVehicle() => vehicle.vehicles;

        public IEnumerable<Vehicle> viewVehicle(int Id) => vehicle.vehicles.Where(v => v.customerId == Id);

        public bool add(Vehicle veh) => vehicle.Add(veh);

        public bool update(Vehicle veh) => vehicle.Update(veh);

    }
}
