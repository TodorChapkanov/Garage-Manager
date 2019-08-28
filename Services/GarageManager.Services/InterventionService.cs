using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class InterventionService : BaseService, IInterventionService
    {
        private readonly IDeletableEntityRepository<ServiceIntervention> serviceRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public InterventionService(
            IDeletableEntityRepository<ServiceIntervention> serviceRepository,
            IDateTimeProvider dateTimeProvider)
        {
            this.serviceRepository = serviceRepository;
            this.dateTimeProvider = dateTimeProvider;
        }
        public async Task<IEnumerable<CarServiceHistory>> GetCarServicesHistoryByCarIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var services = await this.serviceRepository
                    .All()
                    .Where(service => service.CarId == id && service.IsFinished == true)
                      .Select(service => new CarServiceHistory
                      {
                          Id = service.Id,
                          CarMake = service.Car.Make.Name,
                          CarRegistrtionPlate = service.Car.RegistrationPlate,
                          FinishedOn = service.FinishedOn,
                          Price = service.Parts
                          .Sum(part => part.TotalCost)
                          + service.Repairs
                          .Sum(intervention => intervention.TotalCosts)

                      })
                      .ToListAsync();

                return services;
            }
            catch
            {
                return null;
            }
        }

        public async Task<CarServiceHistoryDetails> GetServiceHistoryDetailsByIdAsync(string serviceId)
        {
            try
            {
                this.ValidateNullOrEmptyString(serviceId);

                var model = await this.serviceRepository
                .All()
                .Where(service => service.Id == serviceId)
                .To<CarServiceHistoryDetails>()
                .FirstOrDefaultAsync();

                return model;
            }
            catch
            {
                return null;
            }
        }

        public async Task<int> FinishServiceByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var serviceIntervention = await this.serviceRepository.GetEntityByKeyAsync(id);
                serviceIntervention.FinishedOn = this.dateTimeProvider.GetDateTime();
                serviceIntervention.IsFinished = true;
                return await this.serviceRepository.Update(serviceIntervention);
            }
            catch
            {
                return default(int);
            }

        }

        public IDictionary<int, int> GetFinishedCarsForCurrentMunth()
        {
            var serviceHistory = this.serviceRepository
                .All()
                .Where(service => service.FinishedOn.Month == DateTime.Now.Month && service.IsFinished == true)
                .GroupBy(ser => ser.FinishedOn.Day)
                .ToDictionary(ser => ser.Key, ser => ser.Count());

            return serviceHistory;
        }
    }
}
