using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;

namespace GarageManager.DAL
{
    public class TransmissionTypeRepository : RepositoryBase<TransmissionType, string>, ITransmissionTypeRepository
    {
        public TransmissionTypeRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<TransmissionType> GetAllTransmissionTypes()
        {
            return base.All();
        }
    }
}
