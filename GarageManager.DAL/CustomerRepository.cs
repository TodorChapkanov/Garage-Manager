using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL
{
    public class CustomerRepository : RepositoryBase<Customer, string>, ICustomerRepository
    {
        public CustomerRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Customer> GetAll()
        {
            return base.All();
        }

        public async Task<Customer> GetByIdAsync(string id)
        {
            var customer = await base.GetAsync(id);

            return customer;
        }

    
    }
}
