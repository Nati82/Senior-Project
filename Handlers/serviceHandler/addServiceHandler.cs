using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualBasic;
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
    public class addServiceHandler
    {
    
        IAddServRepository addServ;
        IStatOfVehicleRepository statOfVehicleRepository;
       
        public addServiceHandler(IAddServRepository addServ, IStatOfVehicleRepository statOfVehicleRepository)
        {
            this.addServ = addServ;
            this.statOfVehicleRepository = statOfVehicleRepository;
        }

        public IEnumerable<additionalService> viewAddServCust(int custId)
        {
            IEnumerable<additionalService> additionalServices = new Collection<additionalService>();
            var stat = statOfVehicleRepository.statusOfVehicles.Where(s => s.customerId == custId);
            foreach (var s in stat)
                additionalServices.Concat(addServ.additionalServices
                        .Where(a => a.statusOfVehicleId == s.Id));

            return additionalServices;
        }

        public IEnumerable<additionalService> viewAddServMech(int mechId)
        {
            IEnumerable<additionalService> additionalServices = new Collection<additionalService>();
            var stat = statOfVehicleRepository.statusOfVehicles.Where(s => s.mechanicId == mechId);
            foreach (var s in stat)
            additionalServices.Concat(addServ.additionalServices
                    .Where(a => a.statusOfVehicleId == s.Id))
                    .Where(a => a.approved == true);

            return additionalServices;
        }

        public IEnumerable<additionalService> viewAddService(int statusId) => 
            addServ.additionalServices.Where(a => a.statusOfVehicleId == statusId);

        public bool updateAddService(additionalService additionalService) =>
            addServ.Update(additionalService);
       
        public bool sendAddReqCustomer(additionalService additionalService) =>
            addServ.Add(additionalService);
        
        
        public bool sendAddReqMech(additionalService additionalService) =>
            addServ.Add(additionalService);
    
    }
}
