using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Senior_Project.DataBase;
using Senior_Project.IRepository.IServices;
using Senior_Project.Models.Services;

namespace Senior_Project.Repositories.Services
{
    public class serviceRepository : IServiceRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Service> services => context.Services.Include(s => s.listOfGarages);
        public bool Add(Service service)
        {
            context.Services.Add(service);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Service service)
        {
            context.Services.Update(service);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
