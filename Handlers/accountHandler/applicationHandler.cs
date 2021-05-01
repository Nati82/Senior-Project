using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using Senior_Project.Repositories.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.accountHandler
{
    public class applicationHandler
    {
        IApplicationRepository applicationRepository;
        IMechanicRepository mechanicRepository;
        IGarageRepository garageRepository;
        ILocationRepository locationRepository;
        public applicationHandler(IApplicationRepository applicationRepository, IMechanicRepository mechanicRepository, IGarageRepository garageRepository, ILocationRepository locationRepository)
        {
            this.mechanicRepository = mechanicRepository;
            this.applicationRepository = applicationRepository;
            this.garageRepository = garageRepository;
            this.locationRepository = locationRepository;
        }

        public IEnumerable<Application> Get() => applicationRepository.applications;

        public bool apply(Application application)
         => applicationRepository.Add(application);

        public bool approveMechanic(Application application)
        {
            var mechanic = new Mechanic();
            var holder = applicationRepository.Update(application);
            
            if(holder)
            {
                mechanic.firstName = application.firstName;
                mechanic.lastName = application.lastName;
                mechanic.username = application.username;
                mechanic.phoneNumber = application.phoneNumber;
                mechanic.password = application.password;
                mechanic.email = application.email;
                mechanic.GarageId = application.GarageId;
            }
            
            return mechanicRepository.Add(mechanic);
        }

        public bool approveGarage(Application application)
        {
            Garage garage = new Garage();
            Location location = new Location();
            var holder = applicationRepository.Update(application);
            bool gar, loc;
            if (holder)
            {
                garage.garageName = application.garageName;
                garage.username = application.username;
                garage.password = application.password;
                garage.email = application.email;
                garage.phoneNumber = application.phoneNumber;

            }
            gar = garageRepository.Add(garage);

            var garageId = garageRepository.garages.Where(g => g.username == application.username).Select(g => g.Id).FirstOrDefault();

            if(garageId != 0)
            {
                location.ApplicationId = application.Id;
                location.GarageId = garageId;
                location.longitude = application.longitude;
                location.latitude = application.lattitude;
            }

            loc = locationRepository.Add(location);

            return gar && loc;
        }
            
    }
}
