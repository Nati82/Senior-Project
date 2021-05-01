using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senior_Project.Handlers.notificationHandler;
using Senior_Project.IRepository.INotifications;
using Senior_Project.Models.Notifications;

namespace Senior_Project.Controllers.notificationController
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class notificationController : ControllerBase
    {
        private readonly IServAssReqRepository servAssReqRepository;
        private readonly INotificationRepository notificationRepository;
        notificationHandler nh;
        
        public notificationController(
            IServAssReqRepository servAssReqRepository, 
            INotificationRepository notificationRepository)
        {
            this.servAssReqRepository = servAssReqRepository;
            this.notificationRepository = notificationRepository;
            nh = new notificationHandler(this.servAssReqRepository, this.notificationRepository);
        }

        [HttpPost("assistance")]
        public IActionResult sendAssReq([FromBody] serviceAssistanceRequest serviceAssistanceRequest)
           => Ok(nh.sendAssistanceReq(serviceAssistanceRequest));

        [HttpPatch]
        public IActionResult acceptAssistReq([FromBody] serviceAssistanceRequest serviceAssistanceRequest)
            => Ok(nh.acceptAssistanceReq(serviceAssistanceRequest));

        [HttpGet("mechanic/{mechID}")]
        public IActionResult receiveNotificationMech(int mechId) 
            => Ok(nh.receiveNotificationMechanic(mechId));

        [HttpGet("{garageID}")]
        public IActionResult receiveAssistReq(int garageId)
            => Ok(nh.receiveAssistReq(garageId));

        [HttpGet("customer/{custId}")]
        public IActionResult receiveNotificationCust(int custId)
            => Ok(nh.receiveNotificationCustomer(custId));

        [HttpPost]
        public IActionResult sendNotification([FromBody] Notification notification)
            => Ok(nh.sendNotification(notification));

        [HttpGet("notification/{notifId}")]
        public IActionResult viewNotification(int notifId)
            => Ok(nh.viewNotification(notifId));
    }
}