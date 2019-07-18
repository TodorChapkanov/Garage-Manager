using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Part;
using Microsoft.EntityFrameworkCore;
using System;
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
            decimal price,
            int quantity)
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
                Quantity = quantity,
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

        public async Task<PartEditDetils> GetEditDetailsByIdAsync(string id)
        {
            var partFromDb = (await this.partRepository.GetAsync(id));

            var part = new PartEditDetils
            {
                Id = partFromDb.Id,
                Name = partFromDb.Name,
                Number = partFromDb.Number,
                Price = partFromDb.Price,
                Quantity = partFromDb.Quantity
            };

            return part;
        }

        public async Task<bool> UpdatePartByIdAsync(
            string id,
            string name,
            string number,
            decimal price,
            int quantity)
        {
            //TODO Resolve the problem with disposing DbContext

            var partFromDb = await this.partRepository.GetEntityByKeyAsync(id);//.All().FirstOrDefault(part => part.Id == id);
                partFromDb.Name = name;
                partFromDb.Number = number;
                partFromDb.Price = price;
                partFromDb.Quantity = quantity;

                await this.partRepository.UpdateAsync(partFromDb);
        
           /* catch (Exception ms)
            {
                throw new InvalidOperationException("Invalid Part Details!");
            }*/

            return true;
        }
    }
}
