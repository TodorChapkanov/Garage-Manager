using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;
using System;
using System.Linq;
using System.Text;


namespace GarageManager.DAL
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
