using GarageManager.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL.Contracts
{
    public interface IFuelTypeRepository : IRepository<FuelType>
    {
        IQueryable<FuelType> GetAllTypesAsync();
    }
}
