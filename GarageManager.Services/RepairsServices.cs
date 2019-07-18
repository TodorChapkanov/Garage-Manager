using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class RepairsServices : IRepairsServices
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<Repair> repairRepository;
        private readonly IDeletableEntityRepository<ServiceRepair> serviceRepairRepository;

        public RepairsServices(
            IDeletableEntityRepository<Car> carRepository,
            IDeletableEntityRepository<Repair> repairRepository,
            IDeletableEntityRepository<ServiceRepair> serviceRepairRepository)
        {
            this.carRepository = carRepository;
            this.repairRepository = repairRepository;
            this.serviceRepairRepository = serviceRepairRepository;
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
                    ServiceId = car.Services.Id,
                    car.DepartmentId
                })
                .FirstOrDefaultAsync();

            var repairService = new Repair
            {
                Description = description,
                Hours = hours,
                PricePerHour = pricePerHour,
                DepartmentId = carFromDb.DepartmentId
            };
            await this.repairRepository.CreateAsync(repairService);
            await this.serviceRepairRepository
                .CreateAsync(new ServiceRepair
                {
                    RepairId = repairService.Id,
                    ServiceId = carFromDb.ServiceId
                });

            return carFromDb.Carid;
        }
    }
}
