using GarageManager.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IQueryable<Customer> GetAll();

        Task<Customer> GetByIdAsync(string id);

    }
}
