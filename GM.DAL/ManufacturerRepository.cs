using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;
using System;
using System.Linq;
using System.Text;


namespace GM.DAL
{
    public class ManufacturerRepository : RepositoryBase<VehicleManufacturer, string>, IManufacturerRepository
    {
        public ManufacturerRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<VehicleManufacturer> GetAll()
        {
            var result = base.All();

            return result;
        }

       
    }
}
