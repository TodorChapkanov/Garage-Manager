using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
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

        public async Task<IEnumerable<VehicleManufacturer>> GetAllAsync()
        {
            var result = await this.repository.All().ToListAsync();

            return result;
        }
    }
}
