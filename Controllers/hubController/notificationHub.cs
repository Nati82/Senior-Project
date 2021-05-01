using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis;
using Senior_Project.IRepository.INotifications;
using Senior_Project.IRepository.IServices;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models;
using Senior_Project.Models.Notifications;
using Senior_Project.Models.Services;
using Senior_Project.Models.Vehicles;
using Senior_Project.Repositories.Notifications;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Controllers.hubController
{
    public class notificationHub:Hub
    {
        INotificationRepository notificationRepository;
        IAddServRepository addServRepository;
        IServAssReqRepository servAssReqRepository;
        IStatOfVehicleRepository statOfVehicleRepository;
        IServiceRepository serviceRepository;
        public notificationHub(IServiceRepository serviceRepository, INotificationRepository notificationRepository, IAddServRepository addServRepository, IServAssReqRepository servAssReqRepository, IStatOfVehicleRepository statOfVehicleRepository)
        {
            this.serviceRepository = serviceRepository;
            this.notificationRepository = notificationRepository;
            this.statOfVehicleRepository = statOfVehicleRepository;
            this.addServRepository = addServRepository;
            this.servAssReqRepository = servAssReqRepository;
        }
        public async Task sendMessage(ChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public async Task sendAdditional(Notification notification, additionalService additionalService , Collection<Service> services)
        {
            addServRepository.Add(additionalService);
            var serv = addServRepository.additionalServices.Last();





            serv = addServRepository.additionalServices.Last();

            var s = typeof(additionalService).ToString();
            notification.type = s.Split(".").Last();
            notification.objectId = serv.Id;
            //if (notification.mechanicId == 0)
            //{
            //    int mechId = statOfVehicleRepository.statusOfVehicles
            //        .Where(s => s.Id == serv.statusOfVehicleId)
            //        .Select(s => s.mechanicId).FirstOrDefault();
            //    notification.mechanicId = mechId;
            //    notificationRepository.Add(notification);
            //    var notif = notificationRepository.notifications.Last();
            //    await Clients.All.SendAsync("ReceiveAdditionalRequest", notif, mechId);
            //}
            //else if (notification.customerId == 0)
            //{
                int custId = statOfVehicleRepository.statusOfVehicles
                    .Where(s => s.Id == serv.statusOfVehicleId)
                    .Select(s => s.customerId).FirstOrDefault();
                notification.customerId = custId;
                notificationRepository.Add(notification);
                var notif = notificationRepository.notifications.Last();
                await Clients.All.SendAsync("ReceiveNotification", notif);
            //}
            //else await Clients.All.SendAsync("notif", "hello");
        }

        public async Task sendNotification(Notification notification, int statusOfVehicleId)
        {
            if(notification.customerId == 0)
            {
                var custId = this.statOfVehicleRepository.statusOfVehicles
                    .Where(s => s.Id == statusOfVehicleId)
                    .Select(s => s.customerId).FirstOrDefault();
                notification.customerId = custId;
                this.notificationRepository.Add(notification);
            }

            else if (notification.mechanicId == 0)
            {
                var mechId = this.statOfVehicleRepository.statusOfVehicles
                    .Where(s => s.Id == statusOfVehicleId)
                    .Select(s => s.mechanicId).FirstOrDefault();
                notification.mechanicId = mechId;
                var s = typeof(statusOfVehicle).ToString();
                notification.type = s.Split(".").Last();
                this.notificationRepository.Add(notification);
            }
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }
        public async Task sendNotification2(Notification notification)
        {
            notificationRepository.Add(notification);
            
            await Clients.All.SendAsync("ReceiveNotification", notification);
        }

        public async Task sendAssistReq(serviceAssistanceRequest serviceAssistance)
        {
            servAssReqRepository.Add(serviceAssistance);
            var serv = servAssReqRepository.serviceAssistanceRequests.Last();

            await Clients.All.SendAsync("ReceiveAssistanceRequest", serv);
        }

        public async Task sendStatusOfVehicle(Notification notification, statusOfVehicle statusOfVehicle)
        {
            statOfVehicleRepository.Add(statusOfVehicle);
            var stat = statOfVehicleRepository.statusOfVehicles.Single(s => s.description == statusOfVehicle.description);
            var s = typeof(statusOfVehicle).ToString();
            notification.type = s.Split(".").Last();
            notification.objectId = stat.Id;
            notificationRepository.Add(notification);
            var notif = notificationRepository.notifications.Last();
            await Clients.All.SendAsync("ReceiveStat", notif,stat);
        }


    }
}
