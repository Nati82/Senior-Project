using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senior_Project.DataBase;
using Senior_Project.IRepository.INotifications;
using Senior_Project.Models.Notifications;

namespace Senior_Project.Repositories.Notifications
{
    public class notificationRepository : INotificationRepository
    {
        private AppDbContext context = new AppDbContext();
        public IEnumerable<Notification> notifications => context.Notifications;
        public bool Add(Notification notification)
        {
            context.Notifications.Add(notification);
            return context.SaveChanges() != 0 ? true : false;
        }
        public bool Update(Notification notification)
        {
            context.Notifications.Update(notification);
            return context.SaveChanges() != 0 ? true : false;
        }
    }
}
