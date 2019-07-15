using GarageManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ITransmissionTypeServices
    {
        Task<IEnumerable<TransmissionType>> GetAllTypesAsync();
    }
}
