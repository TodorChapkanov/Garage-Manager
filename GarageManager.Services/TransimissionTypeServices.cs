using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL.Contracts;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Services
{
    public class TransimissionTypeServices : ITransmissionTypeServices
    {
        private readonly IRepository<TransmissionType> transmissionTypeRepository;

        public TransimissionTypeServices(IRepository<TransmissionType> transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }

        public async Task<IEnumerable<TransmissionType>> GetAllTypesAsync()
        {
            var result = await this.transmissionTypeRepository.All().ToListAsync();

            return result;
        }
    }
}
