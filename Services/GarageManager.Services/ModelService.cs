using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class ModelService : BaseService, IModelService
    {
        private readonly IDeletableEntityRepository<VehicleModel> modelRepositoty;

        public ModelService(IDeletableEntityRepository<VehicleModel> modelRepositoty)
        {
            this.modelRepositoty = modelRepositoty;
        }

        public async Task<IEnumerable<string>> GetAllByMakeIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var result = await this.modelRepositoty.All().Where(make => make.ManufactirerId == id)
                 .Select(model => model.Name)
                 .ToListAsync();
                return result;
            }
            catch 
            {
                return null;
            }
        }
    }
}
