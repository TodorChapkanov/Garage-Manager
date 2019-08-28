using GarageManager.Services.Models.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ICustomerService
    {
        Task<string> CreateAsync(
            string firstName,
            string lastName,
            string email,
            string phoneNumber);

        Task<List<CustomerDetails>> GetAllCustomersDetailsAsync(int pageNumber, string searchTerm);

         Task<CustomerEditDetails> GetCustomerDetailsByIdAsync(string id);

        Task<int> SoftDeleteAsync(string id);

        Task<int> UpdateCustomerByIdAsync(
             string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber);
    }
}
