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
        private readonly IDeletableEntityRepository<Part> partRepository;

        public PartsServices(
            IDeletableEntityRepository<Car> carRepository,
            IDeletableEntityRepository<Part> partRepository)
        {
            this.carRepository = carRepository;
            this.partRepository = partRepository;
        }

        public async Task<string> CreatePartAsync(
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
                ServiceId = carFromDb.CurrentServiceId,
                
            };
            await this.partRepository.CreateAsync(part);
            carFromDb.Services.First(service => service.Id == carFromDb.CurrentServiceId).Parts.Add(part);
            await this.partRepository.SavaChangesAsync();
            return carFromDb.Id;
        }

        public async Task<PartEditDetils> GetEditDetailsByIdAsync(string id)
        {
            var partFromDb = (await this.partRepository.GetEntityByKeyAsync(id));

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

        public async Task<int> UpdatePartByIdAsync(
            string id,
            string name,
            string number,
            decimal price,
            int quantity)
        {

            var partFromDb = await this.partRepository.GetEntityByKeyAsync(id);
                partFromDb.Name = name;
                partFromDb.Number = number;
                partFromDb.Price = price;
                partFromDb.Quantity = quantity;

                 this.partRepository.Update(partFromDb);
            return await this.partRepository.SavaChangesAsync();
        

        }

        public async Task<string> HardDeleteAsync(string id)
        {
                var partFromDb = await this.partRepository.GetEntityByKeyAsync(id);
                this.partRepository.HardDelete(partFromDb);
 await this.partRepository.SavaChangesAsync();

            return partFromDb.ServiceId;
        }
    }
}
