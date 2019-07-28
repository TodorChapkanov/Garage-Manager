using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IDeletableEntityRepository<FuelType> fuelTypeRepository;

        public FuelTypeService(IDeletableEntityRepository<FuelType> fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }

        public async Task<IEnumerable<FuelType>> GetAllTypesAsync()
        {
            var result = await fuelTypeRepository.All().ToListAsync();

            return result;
        }
    }
}
