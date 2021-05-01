using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Accounts
{
    [Table("Locations")]
    public class Location
    {
        public int Id { get; set; }
        public Garage Garage { get; set; }
        public int GarageId { get; set; }
        [Required]
        public float longitude { get; set; }
        [Required]
        public float latitude { get; set; }
        public Application Application { get; set; }
        public int ApplicationId { get; set; }
    }
}
