using GM.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GM.DAL.Contracts
{
    public interface ITransmissionTypeRepository : IRepository<TransmissionType>
    {
        IQueryable<TransmissionType> GetAllTransmissionTypes();
    }
}
