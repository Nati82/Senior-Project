using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Accounts
{
    [Table("Garages")]
    public class Garage
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string garageName { get; set; }
        [Required]
        [StringLength(255)]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [StringLength(255)]
        public string email { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        public float rating { get; set; }
        public bool removed { get; set; }
        public bool available { get; set; }
        [NotMapped]
        public string token { get; set; }

    }
}
