using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.Models.Accounts;

namespace Senior_Project.Models.Vehicles
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public string vehicleType { get; set; }
        public int plateNumber { get; set; }
        public int plateCode { get; set; }
        public string countryCode { get; set; }
        public string color { get; set; }
        public Customer customer { get; set; }
        public int customerId { get; set; }
    }
}
