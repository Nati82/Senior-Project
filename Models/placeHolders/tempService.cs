using Senior_Project.Models.Accounts;
using Senior_Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.placeHolders
{
    public class tempService
    {
        public string username { get; set; }
        public string oldpassword { get; set; }
        public string newpassword { get; set; }
        public int garageId { get; set; }
        public int serviceId { get; set; }
        public Garage garage { get; set; }
        public ICollection<Garage> garages { get; set; }
        public Service service { get; set; }
    }
}
