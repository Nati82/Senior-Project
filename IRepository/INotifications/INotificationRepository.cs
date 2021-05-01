using Senior_Project.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.INotifications
{
    public interface INotificationRepository
    {
        IEnumerable<Notification> notifications { get; }
        public bool Add(Notification notification);
        public bool Update(Notification notification);
    }
}
