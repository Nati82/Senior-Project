using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.INotifications;
using Senior_Project.Models.Notifications;

namespace Senior_Project.Repositories.Notifications
{
    public class servAssReqRepository : IServAssReqRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<serviceAssistanceRequest> serviceAssistanceRequests => context.serviceAssistanceRequests;
        public bool Add(serviceAssistanceRequest serviceAssistanceRequest)
        {
            serviceAssistanceRequest.date = DateTime.UtcNow;
            context.serviceAssistanceRequests.Add(serviceAssistanceRequest);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(serviceAssistanceRequest serviceAssistanceRequest)
        {
            context.serviceAssistanceRequests.Update(serviceAssistanceRequest);
            return context.SaveChanges() != 0 ? true : false; ;
        }
    }
}
