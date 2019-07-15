using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL.Contracts;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Services
{
    public class FuelTypeServices : IFuelTypeServices
    {
        private readonly IRepository<FuelType> fuelTypeRepository;

        public FuelTypeServices(IRepository<FuelType> fuelTypeRepository)
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
