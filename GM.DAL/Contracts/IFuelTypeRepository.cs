using GM.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GM.DAL.Contracts
{
    public interface IFuelTypeRepository : IRepository<FuelType>
    {
        IQueryable<FuelType> GetAllFuelTypes();
    }
}
