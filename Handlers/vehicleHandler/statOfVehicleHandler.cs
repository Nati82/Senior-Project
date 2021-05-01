using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.vehicleHandler
{
    public class statOfVehicleHandler
    {
        IStatOfVehicleRepository statOfVehicle;
        IVehicleRepository vehicle;
        IMechanicRepository mechanic;
        ICustomerRepository customer;

        public statOfVehicleHandler(ICustomerRepository customer, IMechanicRepository mechanic, IStatOfVehicleRepository statOfVehicle, IVehicleRepository vehicle)
        {
            this.customer = customer;
            this.mechanic = mechanic;
            this.statOfVehicle = statOfVehicle;
            this.vehicle = vehicle;
        }

        public IEnumerable<statusOfVehicle> viewStatusmechanic(int mechanicId) => statOfVehicle.statusOfVehicles.Where(s => s.mechanicId == mechanicId);

        public IEnumerable<statusOfVehicle> viewStatus() => statOfVehicle.statusOfVehicles;

        public IEnumerable<statusOfVehicle> viewStatus(int sovId) => statOfVehicle.statusOfVehicles.Where(s => s.Id == sovId);

        public IEnumerable<statusOfVehicle> viewStatusCustomer(int CustomerId) => statOfVehicle.statusOfVehicles.Where(s => s.customerId == CustomerId);

     

        public bool createStatus(statusOfVehicle stat)
        {
            stat.date = DateTime.Now;
            return statOfVehicle.Add(stat);
        }
        public bool approveStatus(statusOfVehicle stat) => statOfVehicle.Update(stat);

    }
}
