﻿using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Part;
using GarageManager.Services.DTO.Repair;
using GarageManager.Services.DTO.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class InterventionServices : IInterventionServices
    {
        private readonly IDeletableEntityRepository<ServiceIntervention> serviceRepository;
        private readonly IDateTimeProvider dateTimeProvider;

        public InterventionServices(
            IDeletableEntityRepository<ServiceIntervention> serviceRepository,
            IDateTimeProvider dateTimeProvider)
        {
            this.serviceRepository = serviceRepository;
            this.dateTimeProvider = dateTimeProvider;
        }
        public async Task<List<CarServiceHistory>> CarServicesHistoryAsync(string id)
        {
            var services = await this.serviceRepository.All()
                .Include(service => service.Car)
                .ThenInclude(car => car.Manufacturer)
                .Include(service => service.Parts)
                .Include(service => service.Repairs)
                .Where(service => service.CarId == id && service.IsFinished == true)
                .Select(service => new CarServiceHistory
                {
                    Id = service.Id,
                    CarMake = service.Car.Manufacturer.Name,
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

        public async Task<CarServiceHistoryDetails> ServiceHistoryDetailsAsync(string serviceId)
        {
            //TODO Change Repair Hours to decimal
            var result = await this.serviceRepository
                .All()
                .Where(service => service.Id == serviceId)
                .Include(service => service.Parts)
                .Include(service => service.Repairs)
                .ThenInclude(repair => repair.Employee)
                .Select(service => new CarServiceHistoryDetails
                {
                    CarId = service.CarId,
                    Parts = service.Parts.Select(part => new ServiceHistoryPartDetails
                    {
                        Name = part.Name,
                        Number = part.Number,
                        Quantity = part.Quantity,
                        TotalCost = part.TotalCost
                    }),
                    Repairs = service.Repairs.Select(repair => new ServiceHistoryRepairDetails
                    {
                        Description = repair.Description,
                        EmployeeName = repair.Employee.FullName,
                        Hours = (decimal)repair.Hours,
                        TotalCost = repair.TotalCosts
                    })
                })
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<int> FinishServiceAsync(ServiceIntervention serviceIntervention)
        {
            serviceIntervention.FinishedOn = this.dateTimeProvider.GetDateTime();
            serviceIntervention.IsFinished = true;
            this.serviceRepository.Update(serviceIntervention);
            return await this.serviceRepository.SavaChangesAsync();
        }
    }
}
