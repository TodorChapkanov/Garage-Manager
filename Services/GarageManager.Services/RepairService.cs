using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Repair;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class RepairService : BaseService, IRepairService
    {
        private readonly IDeletableEntityRepository<Repair> repairRepository;
        private readonly IDeletableEntityRepository<Car> carRepository;

        public RepairService(
            IDeletableEntityRepository<Repair> repairRepository,
            IDeletableEntityRepository<Car> carRepository)
        {
            this.repairRepository = repairRepository;
            this.carRepository = carRepository;
        }

        public async Task<string> CreateAsync(
            string carId,
            string description,
            double hours,
            decimal pricePerHour,
            string employeeId)
        {

            

            try
            {
                //TODO Change carRepository to carService
                var carFromDb = await this.carRepository
                .All()
                .FirstOrDefaultAsync(car => car.Id == carId);

                var repairService = new Repair
                {
                    Description = description,
                    Hours = hours,
                    PricePerHour = pricePerHour,
                    ServiceId = carFromDb.ServiceId,
                    EmployeeId = employeeId
                };

                this.ValidateEntityState(repairService);
                await this.repairRepository.CreateAsync(repairService);
               
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
                .All().To<RepairEditDetails>()
                .FirstOrDefaultAsync(repair => repair.Id == id);

                return repairFromDb;
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
