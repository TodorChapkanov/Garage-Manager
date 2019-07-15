using GarageManager.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL.Contracts
{
   public interface ICarRepository
    {
        IQueryable<Car> GetAll();

        Task<bool> CreateNewAsync(Car car);

        IQueryable<Car> GetAllCarsByCustomerId(string customerId);

        Task<Car> GetByIdAsync(string id);

        Task UpdateCarAsync(Car car);
    }
}
