using Microsoft.EntityFrameworkCore.Query.Internal;
using Senior_Project.IRepository.IServices;
using Senior_Project.IRepository.IVehicles;
using Senior_Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.serviceHandler
{
    public class ongoingServiceHandler
    {

        IOnGoingServRepository onGoingServ;
        IStatOfVehicleRepository statOfVehicleRepository;

        public ongoingServiceHandler(IOnGoingServRepository onGoingServ, IStatOfVehicleRepository statOfVehicleRepository)
        {
            this.onGoingServ = onGoingServ;
            this.statOfVehicleRepository = statOfVehicleRepository;
        }

        public IEnumerable<onGoingService> viewOnGoingServCust(int custId)
        {
            IEnumerable<onGoingService> onGoingServices = new Collection<onGoingService>();
            var stat = statOfVehicleRepository.statusOfVehicles.Where(s => s.customerId == custId);
            foreach (var s in stat)
                onGoingServices.Concat(onGoingServ.onGoingServices.Where(a => a.statusOfVehicleId == s.Id));

            return onGoingServices;
        }

        public IEnumerable<onGoingService> viewOnGoingServMech(int mechId)
        {
            IEnumerable<onGoingService> onGoingServices = new Collection<onGoingService> ();
            var stat = statOfVehicleRepository.statusOfVehicles.Where(s => s.mechanicId == mechId);
            foreach (var s in stat)
                onGoingServices.Concat(onGoingServ.onGoingServices.Where(a => a.statusOfVehicleId == s.Id));

            return onGoingServices;
        }

        public IEnumerable<onGoingService> viewOnGoingServ(int statOfVehId) 
            => onGoingServ.onGoingServices
                .Where(o => o.statusOfVehicleId == statOfVehId)
                .Where(o => o.serviceFinished != true);

        public bool updateOnGoServMechanic(onGoingService onGoingService) 
            => onGoingServ.Update(onGoingService);

        public bool createOnGoservMechanic(onGoingService onGoingService) 
            => onGoingServ.Add(onGoingService);
         
    }
}
