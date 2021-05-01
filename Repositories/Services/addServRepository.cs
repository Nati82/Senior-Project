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
    public class addServRepository : IAddServRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<additionalService> additionalServices => context.additionalServices.Include(a => a.listOfServices);
        public bool Add(additionalService additionalService)
        {
            context.additionalServices.Add(additionalService);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(additionalService additionalService)
        {
            context.additionalServices.Update(additionalService);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
