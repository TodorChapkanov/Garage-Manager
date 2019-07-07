using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL
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
    }
}
