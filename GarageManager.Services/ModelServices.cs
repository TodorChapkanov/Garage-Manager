using GarageManager.DAL.Contracts;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class ModelServices : IModelServices
    {
        private readonly IModelRepositoty modelRepositoty;

        public ModelServices(IModelRepositoty modelRepositoty)
        {
            this.modelRepositoty = modelRepositoty;
        }

        public async Task<IEnumerable<string>> GetAllByMakeIdAsync(string id)
        {
            var result = await (this.modelRepositoty.GetAllModelsById(id)
                 .Select(model => model.Name)
                 .ToListAsync());

            return result;
        }

        public async Task<VehicleModel> GetByNameAsync(string name)
        {
            var result = await this.modelRepositoty.GetByNameAsync(name);

            return result;
        }
    }
}
