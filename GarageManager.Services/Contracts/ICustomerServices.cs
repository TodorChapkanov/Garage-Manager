using GarageManager.Domain;
using GarageManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ICustomerServices
    {
        Task CreateNewAsync(
            string firstName,
            string lastName,
            string email,
            string phoneNumber);

        Task<List<Customer>> GetAllAsync();
        Task<List<CustomerDetail>> GetAllCustomersDetailsAsync();

         Task<CustomerEditDetails> EditCustomerDetailsByIdAsync(string id);

     

        Task<bool> UpdateCustomerByIdAsync(
             string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber);
    }
}
