using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Accounts
{
    [Table("Applications")]
    public class Application
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string firstName { get; set; }
        [Required]
        [StringLength(255)]
        public string lastName { get; set; }
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
        public int GarageId { get; set; }
        public bool approval { get; set; }
        public float longitude { get; set; }
        public float lattitude { get; set; }
    }
}
