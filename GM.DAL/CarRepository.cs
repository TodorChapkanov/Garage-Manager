using System.Linq;
using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;

namespace GM.DAL
{
    public class CarRepository : RepositoryBase<Car, string>, ICarRepository
    {
        public CarRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Car> GetAll()
        {
            

            return null;
        }
    }
}
