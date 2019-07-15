using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.DAL
{
    public class ModelRepository : RepositoryBase<VehicleModel, string>, IModelRepositoty
    {
        public ModelRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public  IQueryable<VehicleModel> GetAllModelsById(string id)
        {
            var result = dbContext.VehicleModels.Where(model => model.ManufactirerId == id);

            return result;
        }

        public async Task<VehicleModel> GetByNameAsync(string name)
        {
            var result = await base.All().FirstOrDefaultAsync(model => model.Name == name);

            return result;
        }
    }
}
