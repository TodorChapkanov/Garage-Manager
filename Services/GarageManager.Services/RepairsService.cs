using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Repair;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class RepairsService : BaseService, IRepairsService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<Repair> repairRepository;

        public RepairsService(
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

            try
            {
                var repairService = new Repair
                {
                    Description = description,
                    Hours = hours,
                    PricePerHour = pricePerHour,
                    ServiceId = carFromDb.CurrentServiceId,
                    EmployeeId = employeeId
                };

                this.ValidateEntityState(repairService);
                await this.repairRepository.CreateAsync(repairService);
                carFromDb.Services.First(service => service.Id == carFromDb.CurrentServiceId).Repairs.Add(repairService);
               

                return carFromDb.Id;
            }
            catch 
            {
                return null;
            }
            
        }

        public async Task<RepairEditDetails> GetEditDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var repairFromDb = await this.repairRepository
                .All()
                .FirstOrDefaultAsync(repair => repair.Id == id);

                var part = new RepairEditDetails
                {
                    Id = repairFromDb.Id,
                    Description = repairFromDb.Description,
                    Hours = repairFromDb.Hours,
                    PricePerHour = repairFromDb.PricePerHour,
                    EmployeeName = repairFromDb.Employee.FullName,
                    IsFinished = repairFromDb.IsFinished
                };

                return part;
            }
            catch 
            {
                return null;
            }
            
        }

        public async Task<int> UpdateRepairByIdAsync(
            string id,
            string description,
            double hours,
            decimal pricePerHour,
            bool isFinished)
        {
            try
            {
                var repairFromDb = await this.repairRepository.GetEntityByKeyAsync(id);
                repairFromDb.Description = description;
                repairFromDb.Hours = hours;
                repairFromDb.PricePerHour = pricePerHour;
                repairFromDb.IsFinished = isFinished;

                this.ValidateEntityState(repairFromDb);
              return await this.repairRepository.Update(repairFromDb);
            }
            catch 
            {
                return default(int);
            }
           
        }

        public async Task<int> HardDeleteAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var repairFromDb = await this.repairRepository.GetEntityByKeyAsync(id);
                return await this.repairRepository.HardDelete(repairFromDb);

                 
            }
            catch 
            {
                return default(int);
            }
            
        }
    }
}
