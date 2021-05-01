using Senior_Project.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Services
{
    [Table("additionalServices")]
    public class additionalService
    {
        public int Id { get; set; }
        public statusOfVehicle statusOfVehicle { get; set; }
        public int statusOfVehicleId { get; set; }
        public DateTime expectedDate { get; set; }
        public bool serviceFinished { get; set; }
        public float totalPrice { get; set; }
        public bool approved { get; set; }
        public ICollection<Service> listOfServices { get; set; }

        public additionalService()
        {
            listOfServices = new Collection<Service>();
        }
    }
}