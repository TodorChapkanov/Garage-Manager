using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class TransimissionTypesServices : ITransmissionTypesServices
    {
        private readonly IDeletableEntityRepository<TransmissionType> transmissionTypeRepository;

        public TransimissionTypesServices(IDeletableEntityRepository<TransmissionType> transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }

        public async Task<IEnumerable<TransmissionType>> GetAllTypesAsync()
        {
            var result = await this.transmissionTypeRepository
                .All()
                .ToListAsync();

            return result;
        }
    }
}
