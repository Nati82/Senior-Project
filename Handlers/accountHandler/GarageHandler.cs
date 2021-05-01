using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.accountHandler
{
    public class GarageHandler
    {
        IGarageRepository garageRepository;
        IApplicationRepository applicationRepository;
        ILocationRepository locationRepository;

        public GarageHandler(IApplicationRepository applicationRepository, IGarageRepository garageRepository, ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
            this.applicationRepository = applicationRepository;
            this.garageRepository = garageRepository;
        }
        public bool signUp(Application garage)
        {
            if (!garageRepository.garages.Any(g => g.username == garage.username))
                return applicationRepository.Add(garage);
            else 
                return false;
        }

        public bool changePassWord(tempService garage)
        {
            var gar = Get(garage.username);
            if (gar.password == garage.oldpassword)
                gar.password = garage.newpassword;
            else return false;

            return garageRepository.Update(gar);
        }

        public IEnumerable<Location> GetLocation()
        {
            return locationRepository.locations;
        }

        public IEnumerable<Garage> Get()
        {
            return garageRepository.garages;
        }

        public Garage Get(string username)
        {
            return garageRepository.garages.Where(g => g.username == username).FirstOrDefault();
        }
    }
}
