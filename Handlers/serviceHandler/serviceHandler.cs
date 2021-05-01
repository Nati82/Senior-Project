using Newtonsoft.Json;
using Senior_Project.IRepository.IAccounts;
using Senior_Project.IRepository.IServices;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.Services;
using SQLitePCL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.serviceHandler
{
    public class serviceHandler
    {
        IServiceRepository service;
        IGarageRepository garage;

        public serviceHandler(IServiceRepository service, IGarageRepository garage)
        {
            this.service = service;
            this.garage = garage;
        }

        public IEnumerable<Service> viewServiceGar(int garageId)
        {
            var gar = garage.garages.Single(g => g.Id == garageId);
            return service.services.Where(s =>
            {
                var garage = s.listOfGarages.Single(g => g.username == gar.username);
                return garage != null;
            });
        }

        public IEnumerable<Service> viewService(string username)
            => service.services.Where(s => 
            {
                var garage = s.listOfGarages.Single(g => g.username == username);
                return garage != null;
            });

        public IEnumerable<Service> viewServiceAdmin() => service.services;

        public bool createService(Service serv) => service.Add(serv);
        
        
        public bool addServiceGarage(Service serv, Garage garag)
        {
            var servi = service.services.Single(s=>s.Id == serv.Id);
            servi.listOfGarages.Add(garag);
            return service.Update(servi); 
        }

        public bool updateServiceGarage(Service serv)
            => service.Update(serv);            
        

        public bool removeServiceGarage(int servId, int garId)
        {
            var services = service.services.Single(s => s.Id == servId);
            var garage = services.listOfGarages.Single(g => g.Id == garId);
            services.listOfGarages.Remove(garage);
            return service.Update(services);
        }

        public bool removeServiceAdmin(int servId)
        {
            var filteredServ = service.services.Single(s => s.Id == servId);
            filteredServ.removed = true;
            return service.Update(filteredServ);
        }

    }
}
