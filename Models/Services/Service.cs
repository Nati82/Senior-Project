using Senior_Project.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Models.Services
{
    [Table("Services")]
    public class Service
    {
        public int Id { get; set; }
        public string serviceName { get; set; }
        public float estimatedPrice { get; set; }
        public bool removed { get; set; }
        public ICollection<Garage> listOfGarages { get; set; }

        public Service()
        {
            listOfGarages = new Collection<Garage>();
        }
    }
}
