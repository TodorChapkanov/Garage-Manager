using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.DAL
{
    public class FuelTypeRepository : RepositoryBase<FuelType, string>, IFuelTypeRepository

    {
        public FuelTypeRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<FuelType> GetAllFuelTypes()
        {
            return base.All();
        }
    }
}
