using GM.Domain;
using System.Linq;

namespace GM.DAL.Contracts
{
   public interface ICarRepository
    {
        IQueryable<Car> GetAll();
    }
}
