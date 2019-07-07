using GM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM.DAL.Contracts
{
    public interface IModelRepositoty : IRepository<VehicleModel>
    {
         IQueryable<VehicleModel> GetAllModelsById(string id);
    }
}
