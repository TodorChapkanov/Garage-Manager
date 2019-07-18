using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class ModelServices : IModelServices
    {
        private readonly IDeletableEntityRepository<VehicleModel> modelRepositoty;

        public ModelServices(IDeletableEntityRepository<VehicleModel> modelRepositoty)
        {
            this.modelRepositoty = modelRepositoty;
        }

        public async Task<IEnumerable<string>> GetAllByMakeIdAsync(string id)
        {
            var result = await this.modelRepositoty.All().Where(make => make.ManufactirerId == id)
                 .Select(model => model.Name)
                 .ToListAsync();

            return result;
        }

        public async Task<VehicleModel> GetByNameAsync(string name)
        {
            var result = await this.modelRepositoty.All().FirstOrDefaultAsync(model => model.Name == name);

            return result;
        }
    }
}
