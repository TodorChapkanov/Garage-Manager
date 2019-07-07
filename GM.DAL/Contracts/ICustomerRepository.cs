using GM.Domain;
using System.Linq;

namespace GM.DAL.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetAll();
    }
}
