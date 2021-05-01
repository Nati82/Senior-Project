using Senior_Project.Handlers.serviceHandler;
using Senior_Project.IRepository.INotifications;
using Senior_Project.IRepository.IServices;
using Senior_Project.Models.Notifications;
using Senior_Project.Models.Services;
using Senior_Project.Repositories.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.notificationHandler
{
    public class notificationHandler
    {
        IServAssReqRepository servAssReqRepository;
        INotificationRepository notificationRepository;

        public notificationHandler(IServAssReqRepository servAssReqRepository, INotificationRepository notificationRepository)
        {
            this.servAssReqRepository = servAssReqRepository;
            this.notificationRepository = notificationRepository;
        }

        public bool sendAssistanceReq(serviceAssistanceRequest serviceAssistanceRequest)
            => servAssReqRepository.Add(serviceAssistanceRequest);

        public bool acceptAssistanceReq(serviceAssistanceRequest serviceAssistanceRequest)
            => servAssReqRepository.Update(serviceAssistanceRequest);

        public IEnumerable<Notification> receiveNotificationCustomer(int customerId)
            => notificationRepository.notifications.Where(s => s.customerId == customerId);

        public IEnumerable<Notification> receiveNotificationMechanic(int mechanicId)
            => notificationRepository.notifications.Where(s => s.customerId == mechanicId);

        public IEnumerable<serviceAssistanceRequest> receiveAssistReq(int garageId)
            => servAssReqRepository.serviceAssistanceRequests.Where(s => s.garageId == garageId);

        public bool sendNotification(Notification notification)
            => notificationRepository.Update(notification);

        public Notification viewNotification(int notifId)
        {
            var notification = notificationRepository.notifications.Single(n => n.Id == notifId);
            notification.received = true;
            notificationRepository.Update(notification);
            return notification;
        }

    }
}
