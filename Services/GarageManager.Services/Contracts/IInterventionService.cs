using GarageManager.Domain;
using GarageManager.Services.DTO.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
   public  interface IInterventionService
    {
        Task<IEnumerable<CarServiceHistory>> GetCarServicesHistoryAsync(string id);
        Task<int> FinishServiceAsync(string id);

        Task<CarServiceHistoryDetails> GetServiceHistoryDetailsAsync(string serviceId);
    }
}
