using System.Collections.Generic;
using System.Threading.Tasks;
using GM.DAL.Contracts;
using GM.Domain;
using GM.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GM.Services
{
    public class TransimissionTypeServices : ITransmissionTypeServices
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransimissionTypeServices(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }

        public Task<List<TransmissionType>> GetAllTypes()
        {
            var result = this.transmissionTypeRepository.GetAllTransmissionTypes().ToListAsync();

            return result;
        }
    }
}
