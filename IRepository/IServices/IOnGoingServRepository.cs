using Senior_Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IServices
{
    public interface IOnGoingServRepository
    {
        IEnumerable<onGoingService> onGoingServices { get; }
        public bool Add(onGoingService onGoingService);
        public bool Update(onGoingService onGoingService);
    }
}
