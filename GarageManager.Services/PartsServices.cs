using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class PartsServices : IPartsServices
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<ServicePart> servicePartRepository;
        private readonly IDeletableEntityRepository<Part> partRepository;

        public PartsServices(
            IDeletableEntityRepository<Car> carRepository,
            IDeletableEntityRepository<ServicePart> servicePartRepository,
            IDeletableEntityRepository<Part> partRepository)
        {
            this.carRepository = carRepository;
            this.servicePartRepository = servicePartRepository;
            this.partRepository = partRepository;
        }

        public async Task<string> CreatePart(
            string carId,
            string name,
            string number,
            decimal price)
        {
            var carFromDb = await this.carRepository
                .All()
                .Where(car => car.Id == carId)
                .Include(service => service.Services)
                .FirstOrDefaultAsync();

            var part = new Part
            {
                Name = name,
                Number = number,
                Price = price,
                DepartmentId = carFromDb.DepartmentId
            };
            await this.partRepository.CreateAsync(part);
            await this.servicePartRepository
                .CreateAsync(new ServicePart
                {
                    PartId = part.Id,
                    ServiceId = carFromDb.Services.Id
                });

            return carFromDb.Id;
        }
    }
}
