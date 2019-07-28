using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class TransimissionTypesService : ITransmissionTypesService
    {
        private readonly IDeletableEntityRepository<TransmissionType> transmissionTypeRepository;

        public TransimissionTypesService(IDeletableEntityRepository<TransmissionType> transmissionTypeRepository)
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
