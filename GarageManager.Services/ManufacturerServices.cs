using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL;
using GarageManager.DAL.Contracts;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.Services
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly IManufacturerRepository repository;

        public ManufacturerServices(IManufacturerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<VehicleManufacturer>> GetAllAsync()
        {
            var result = await this.repository.GetAll().ToListAsync();

            return result;
        }
    }
}
