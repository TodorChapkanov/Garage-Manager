using GarageManager.Services.Models.TransmissionType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ITransmissionTypesService
    {
        Task<IEnumerable<TransmissionTypeDetails>> GetAllTypesAsync();
    }
}
