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
    public class onGoingServRepository : IOnGoingServRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<onGoingService> onGoingServices => context.onGoingServices.Include(a => a.listOfServices);
        public bool Add(onGoingService onGoingService)
        {
            context.onGoingServices.Add(onGoingService);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(onGoingService onGoingService)
        {
            context.onGoingServices.Update(onGoingService);
            return context.SaveChanges() != 0 ? true : false; ;
        }
    }
}
