using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Part;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class PartsService : BaseService, IPartsService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<Part> partRepository;

        public PartsService(
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
            try
            {
                var carFromDb = await this.carRepository
               .All()
               .Where(car => car.Id == carId)
               .FirstOrDefaultAsync();

                var part = new Part
                {
                    Name = name,
                    Number = number,
                    Price = price,
                    Quantity = quantity,
                    ServiceId = carFromDb.CurrentServiceId,

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
                this.partRepository.HardDelete(partFromDb);
                return await this.partRepository.SavaChangesAsync();
            }
            catch 
            {
                return default(int);
            }
        }
    }
}
