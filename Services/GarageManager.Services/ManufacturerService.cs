using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Manufacturer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IDeletableEntityRepository<VehicleManufacturer> repository;

        public ManufacturerService(IDeletableEntityRepository<VehicleManufacturer> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ManufacturerDetails>> GetAllAsync()
        {
            var result = await this.repository
                .All()
                .To<ManufacturerDetails>()
                .ToListAsync();

            return result;
        }
    }
}
