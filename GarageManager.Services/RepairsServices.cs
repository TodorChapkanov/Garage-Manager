using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Repair;
using Microsoft.EntityFrameworkCore;
using System;
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
            decimal pricePerHour)
        {
            var carFromDb = await this.carRepository
                .All()
                .Where(car => car.Id == carId)
                .Include(service => service.Services)
                .Select(car => new
                {
                    Carid = car.Id,
                    Service = car.Services,
                    ServiceId = car.Services.Id,
                    car.DepartmentId
                })
                .FirstOrDefaultAsync();

            var repairService = new Repair
            {
                Description = description,
                Hours = hours,
                PricePerHour = pricePerHour,
                ServiceId = carFromDb.Service.Id
            };
            await this.repairRepository.CreateAsync(repairService);
            carFromDb.Service.Repairs.Add(repairService);

            return carFromDb.Carid;
        }

        public async Task<RepairEditDetails> GetEditDetailsByIdAsync(string id)
        {
            var repairFromDb = (await this.repairRepository.GetAsync(id));

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
        //TODO Resolve the problem with disposing DbContext
        public async Task<bool> UpdatePartByIdAsync(
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

            await this.repairRepository.UpdateAsync(repairFromDb);

            return true;
        }

        public async Task<int> HardDeleteAsync(string id)
        {
            try
            {
                var partFromDb = await this.repairRepository.GetEntityByKeyAsync(id);
                this.repairRepository.HardDelete(partFromDb);
                return int.MaxValue;
            }
            catch (System.Exception ex )
            {

                throw new InvalidOperationException(ex.Message);
            }
            
        }
    }
}
