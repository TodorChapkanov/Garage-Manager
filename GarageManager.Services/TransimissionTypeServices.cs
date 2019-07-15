using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL.Contracts;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Services
{
    public class TransimissionTypeServices : ITransmissionTypeServices
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransimissionTypeServices(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }

        public async Task<IEnumerable<TransmissionType>> GetAllTypesAsync()
        {
            var result = await this.transmissionTypeRepository.GetAllTransmissionTypes().ToListAsync();

            return result;
        }
    }
}
