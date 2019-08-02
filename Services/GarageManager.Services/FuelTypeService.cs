using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.FuelType;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<FuelTypeDetails>> GetAllTypesAsync()
        {
            var result = await fuelTypeRepository
                .All()
                .Select(ft => new FuelTypeDetails
                {
                    Id = ft.Id,
                    Type = ft.Type
                })
                .ToListAsync();

            return result;
        }
    }
}
