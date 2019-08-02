using GarageManager.Domain;
using GarageManager.Services.DTO.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
   public  interface IInterventionService
    {
        Task<IEnumerable<CarServiceHistory>> CarServicesHistoryAsync(string id);
        Task<int> FinishServiceAsync(ServiceIntervention serviceIntervention);

        Task<CarServiceHistoryDetails> ServiceHistoryDetailsAsync(string serviceId);
    }
}
