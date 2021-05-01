using Senior_Project.IRepository.IAccounts;
using Senior_Project.Models.Accounts;
using Senior_Project.Models.placeHolders;
using Senior_Project.Repositories.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.Handlers.accountHandler
{
    public class MechanicHandler
    {
        IGarageRepository garageRepository;
        IMechanicRepository mechanicRepository;
        IApplicationRepository applicationRepository;
        public MechanicHandler(IMechanicRepository mechanicRepository, IGarageRepository garageRepository,IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
            this.garageRepository = garageRepository;
            this.mechanicRepository = mechanicRepository;
        }


        public bool signUp(Application mechanic)
        {
            if (!mechanicRepository.mechanics.Any(m => m.username == mechanic.username))
            {
                var id = garageRepository.garages.Where(g => g.garageName == mechanic.garageName).Select(g => g.Id).FirstOrDefault();
                mechanic.GarageId = id;
                return applicationRepository.Add(mechanic);
            }
            else
                return false;
        }

        public bool changePassWord(tempService mechanic)
        {
            var mech = Get(mechanic.username);
            if (mech.password == mechanic.oldpassword)
                mech.password = mechanic.newpassword;
            else return false;

            return mechanicRepository.Update(mech);
        }

        public Mechanic Get(string username)
        {
            return mechanicRepository.mechanics.Where(m => m.username == username).FirstOrDefault();
        }

        public IEnumerable<Mechanic> Get()
        {
            return mechanicRepository.mechanics;
        }
    }
}
