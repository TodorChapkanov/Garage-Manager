using GarageManager.Domain;
using GarageManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ICustomerService
    {
        Task<int> CreateAsync(
            string firstName,
            string lastName,
            string email,
            string phoneNumber);

        Task<List<CustomerDetail>> GetAllCustomersDetailsAsync();

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
