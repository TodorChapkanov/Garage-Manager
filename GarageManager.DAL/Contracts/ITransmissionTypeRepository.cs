using GarageManager.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL.Contracts
{
    public interface ITransmissionTypeRepository : IRepository<TransmissionType>
    {
        IQueryable<TransmissionType> GetAllTransmissionTypes();
    }
}
