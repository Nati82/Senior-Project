using Senior_Project.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IVehicles
{
    public interface IVehicleRepository
    {
            IEnumerable<Vehicle> vehicles { get; }
            public bool Add(Vehicle vehicle);
            public bool Update(Vehicle vehicle);
    }
}
