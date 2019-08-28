using GarageManager.Domain;
using GarageManager.Services.Models.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public  interface IInterventionService
    {
        Task<IEnumerable<CarServiceHistory>> GetCarServicesHistoryByCarIdAsync(string id);
        Task<int> FinishServiceByIdAsync(string id);

        Task<CarServiceHistoryDetails> GetServiceHistoryDetailsByIdAsync(string serviceId);

        IDictionary<int, int> GetFinishedCarsForCurrentMunth();
    }
}
