using GarageManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ITransmissionTypesService
    {
        Task<IEnumerable<TransmissionType>> GetAllTypesAsync();
    }
}
