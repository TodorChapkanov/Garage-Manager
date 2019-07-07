using System.Linq;
using System.Threading.Tasks;
using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;

namespace GM.DAL
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
