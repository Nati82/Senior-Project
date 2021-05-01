using Senior_Project.Models.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.INotifications
{
    public interface IServAssReqRepository
    {
        IEnumerable<serviceAssistanceRequest> serviceAssistanceRequests { get; }
        public bool Add(serviceAssistanceRequest serviceAssistanceRequest);
        public bool Update(serviceAssistanceRequest serviceAssistanceRequest);
    }
}
