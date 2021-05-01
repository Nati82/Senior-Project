using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Notifications
{
    [Table("serviceAssistanceRequests")]
    public class serviceAssistanceRequest
    {
        public int Id { get; set; }
        public Mechanic mechanic { get; set; }
        public int mechanicId { get; set; }
        public Customer customer { get; set; }
        public int customerId { get; set; }
        public Garage garage { get; set; }
        public int garageId { get; set; }
        public DateTime date { get; set; }
        public bool approval { get; set; }
        public float longitude { get; set; }
        public float lattitude { get; set; }

    }
}
