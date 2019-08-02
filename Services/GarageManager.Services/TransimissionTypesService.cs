using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.TransmissionType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<TransmissionTypeDetails>> GetAllTypesAsync()
        {
            var result = await this.transmissionTypeRepository
                .All().Select(tt => new TransmissionTypeDetails
                {
                    Id = tt.Id,
                    Type = tt.Type
                })
                .ToListAsync();

            return result;
        }
    }
}
