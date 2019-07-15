using GarageManager.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL.Contracts
{
    public interface IModelRepositoty : IRepository<VehicleModel>
    {
         IQueryable<VehicleModel> GetAllModelsById(string id);

        Task<VehicleModel> GetByNameAsync(string name);
    }
}
