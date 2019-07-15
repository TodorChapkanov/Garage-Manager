using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL.Constants;
using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.DAL
{
    public class CarRepository : RepositoryBase<Car, string>, ICarRepository
    {
        public CarRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Car> GetAll()
        {
            var result = base.All();
            return result;
        }

        public async Task<bool> CreateNewAsync(Car car)
        {
            try
            {
                await base.CreateAsync(car);
            }
            catch (System.Exception)
            {
                throw new InvalidOperationException(RepositoryConstants.IvalidCreateCarMessage);
            }

            return true;
        }

        public async Task<Car> GetByIdAsync(string id)
        {
            var result = await base.GetAsync(id);
            return result;
        }

        public  IQueryable<Car> GetAllCarsByCustomerId(string customerId)
        {
            var result =  base.All()
                .Where(car => car.CustomerId == customerId)
                .Include(car => car.Manufacturer)
                .Include(car => car.Model);

            return result;
        }
        public async Task UpdateCarAsync(Car car)
        {
            await base.UpdateAsync(car);
        }
    }
}
