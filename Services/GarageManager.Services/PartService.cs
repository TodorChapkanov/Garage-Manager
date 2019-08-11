using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.Part;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class PartService : BaseService, IPartService
    {
        private readonly IDeletableEntityRepository<Part> partRepository;
        private readonly IDeletableEntityRepository<Car> carRepository;

        public PartService(
            IDeletableEntityRepository<Part> partRepository,
            IDeletableEntityRepository<Car> carRepository
            )
        {
            this.carRepository = carRepository;
            this.partRepository = partRepository;
        }

        public async Task<string> CreateAsync(
            string carId,
            string name,
            string number,
            decimal price,
            int quantity)
        {
            try
            {
                var carFromDb = await this.carRepository
               .All()
               .FirstOrDefaultAsync(car => car.Id == carId);

                var part = new Part
                {
                    Name = name,
                    Number = number,
                    Price = price,
                    Quantity = quantity,
                    ServiceId = carFromDb.ServiceId,

                };

                this.ValidateEntityState(part);
                await this.partRepository.CreateAsync(part);
                return carFromDb.Id;
            }
            catch 
            {
               return null;
            }
           
        }

        public async Task<PartEditDetils> GetEditDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var partFromDb = (await this.partRepository.GetEntityByKeyAsync(id));

                var part = AutoMapper.Mapper.Map<PartEditDetils>(partFromDb);
               

                return part;
            }
            catch 
            {
                return null;
            }
            
        }

        public async Task<int> UpdatePartByIdAsync(
            string id,
            string name,
            string number,
            decimal price,
            int quantity)
        {
            try
            {
                var partFromDb = await this.partRepository.GetEntityByKeyAsync(id);
                partFromDb.Name = name;
                partFromDb.Number = number;
                partFromDb.Price = price;
                partFromDb.Quantity = quantity;
                this.ValidateEntityState(partFromDb);

               return await this.partRepository.Update(partFromDb);
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
                var partFromDb = await this.partRepository.GetEntityByKeyAsync(id);
                return await this.partRepository.HardDelete(partFromDb);
            }
            catch
            {
                return default(int);
            }
        }
    }
}
