﻿using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Repair;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class RepairsServices : IRepairsServices
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<Repair> repairRepository;

        public RepairsServices(
            IDeletableEntityRepository<Car> carRepository,
            IDeletableEntityRepository<Repair> repairRepository)
        {
            this.carRepository = carRepository;
            this.repairRepository = repairRepository;
        }

        public async Task<string> CreateRepairService(
            string carId,
            string description,
            double hours,
            decimal pricePerHour,
            string employeeId)
        {
            var carFromDb = await this.carRepository
                .All()
                .Where(car => car.Id == carId)
                .Include(service => service.Services)
                .FirstOrDefaultAsync(car => car.Id == carId);
            var repairService = new Repair
            {
                Description = description,
                Hours = hours,
                PricePerHour = pricePerHour,
                ServiceId = carFromDb.CurrentServiceId,
                EmployeeId = employeeId
            };
            await this.repairRepository.CreateAsync(repairService);
            carFromDb.Services.First(service => service.Id == carFromDb.CurrentServiceId).Repairs.Add(repairService);
            await this.repairRepository.SavaChangesAsync();

            return carFromDb.Id;
        }

        public async Task<RepairEditDetails> GetEditDetailsByIdAsync(string id)
        {
            var repairFromDb = await this.repairRepository
                .All().Include(repair => repair.Employee)
                .FirstOrDefaultAsync(repair => repair.Id == id);

            var part = new RepairEditDetails
            {
                Id = repairFromDb.Id,
                Description = repairFromDb.Description,
                Hours = repairFromDb.Hours,
                PricePerHour = repairFromDb.PricePerHour,
                IsFinished = repairFromDb.IsFinished
            };

            return part;
        }

        public async Task<int> UpdateRepairByIdAsync(
            string id,
            string description,
            double hours,
            decimal pricePerHour,
            bool isFinished)
        {

            var repairFromDb = await this.repairRepository.GetEntityByKeyAsync(id);   
            repairFromDb.Description = description;
            repairFromDb.Hours = hours;
            repairFromDb.PricePerHour = pricePerHour;
            repairFromDb.IsFinished = isFinished;

            this.repairRepository.Update(repairFromDb);

            return await this.repairRepository.SavaChangesAsync();
        }

        public async Task<string> HardDeleteAsync(string id)
        {

                var repairFromDb = await this.repairRepository.GetEntityByKeyAsync(id);
                this.repairRepository.HardDelete(repairFromDb);
                 await this.repairRepository.SavaChangesAsync();
            return repairFromDb.ServiceId;
        }
    }
}
