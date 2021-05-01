using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Models.Vehicles
{
    [Table("statusOfVehicles")]
    public class statusOfVehicle
    {
        public int Id { get; set; }
        public int vehicleId { get; set; }
        public int mechanicId { get; set; }
        public int customerId { get; set; }
        [Required]
        public string description { get; set; }
        public DateTime date { get; set; }
        public bool approval { get; set; }
    }
}
