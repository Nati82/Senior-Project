using Senior_Project.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senior_Project.IRepository.IServices
{
    public interface IAddServRepository
    {
        IEnumerable<additionalService> additionalServices { get; }
        public bool Add(additionalService additionalService);
        public bool Update(additionalService additionalService);
    }
}
