using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.DAL
{
    public class FuelTypeRepository : RepositoryBase<FuelType, string>, IFuelTypeRepository

    {
        public FuelTypeRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<FuelType> GetAllTypesAsync()
        {
            return base.All();
        }
    }
}
