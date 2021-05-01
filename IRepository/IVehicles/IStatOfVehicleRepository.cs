using Senior_Project.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IVehicles
{
    public interface IStatOfVehicleRepository
    {
        IEnumerable<statusOfVehicle> statusOfVehicles { get; }
        public bool Add(statusOfVehicle statusOfVehicle);
        public bool Update(statusOfVehicle statusOfVehicle);
    }
}
