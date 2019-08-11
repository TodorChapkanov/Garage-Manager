using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.TransmissionType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class TransimissionService : ITransmissionTypesService
    {
        private readonly IDeletableEntityRepository<TransmissionType> transmissionRepository;

        public TransimissionService(IDeletableEntityRepository<TransmissionType> transmissionTypeRepository)
        {
            this.transmissionRepository = transmissionTypeRepository;
        }

        public async Task<IEnumerable<TransmissionTypeDetails>> GetAllTypesAsync()
        {
            var result = await this.transmissionRepository
                .All().Select(tt => new TransmissionTypeDetails
                {
                    Id = tt.Id,
                    Type = tt.Name
                })
                .ToListAsync();

            return result;
        }
    }
}
