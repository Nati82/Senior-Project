using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Notifications
{
    [Table("Notifications")]
    public class Notification
    {
        public int Id { get; set; }
        public string sender  { get; set; }
        public string type { get; set; }
        public int objectId { get; set; }
        public bool received { get; set; }
        public Customer customer { get; set; }
        public int customerId { get; set; }
        public Mechanic mechanic { get; set; }
        public int mechanicId { get; set; }
    }
}
