using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.DAL
{
    public class CustomerRepository : RepositoryBase<Customer, string>, ICustomerRepository
    {
        public CustomerRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public ICollection<object> All()
        {
            return  base.All().Select(customer => new { FullName = customer.FirstName, LastName = customer.LastName, id = customer.Id}).ToList();
        }
        //TODO Create DTO
    }
}
