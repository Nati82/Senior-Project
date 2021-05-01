using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Accounts
{
    [Table("SystemAdmins")]
    public class SystemAdmin
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
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        [StringLength(255)]
        public string email { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        [NotMapped]
        public string token { get; set; }
    }
}
