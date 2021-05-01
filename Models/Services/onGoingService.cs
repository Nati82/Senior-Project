using Senior_Project.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Services
{
    [Table("onGoingServices")]
    public class onGoingService
    {
        public int Id { get; set; }
        public statusOfVehicle statusOfVehicle { get; set; }
        public int statusOfVehicleId { get; set; }
        public DateTime expectedDate { get; set; }
        public bool serviceFinished { get; set; }
        public float totalPrice { get; set; }
        public ICollection<Service> listOfServices { get; set; }

        public onGoingService()
        {
            listOfServices = new Collection<Service>();
        }
    }
}
