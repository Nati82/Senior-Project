using Senior_Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IServices
{
    public interface IServiceRepository
    {
        IEnumerable<Service> services { get; }
        public bool Add(Service service);
        public bool Update(Service service);
    }
}
