using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{

    public class CustomerServices : ICustomerServices
    {
        private readonly IDeletableEntityRepository<Customer> customerRepository;

        public CustomerServices(IDeletableEntityRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task CreateNewAsync(string firstName, string lastName, string email, string phoneNumber)
        {
            var customer = new Customer()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            await this.customerRepository.CreateAsync(customer);
        }

        public Task<List<CustomerDetail>> GetAllCustomersDetailsAsync()
        {

            var allCustomersDetails = this.customerRepository.All()
                 .Select(details => new CustomerDetail
                 {
                     Id = details.Id,
                     FullName = $"{details.FirstName} {details.LastName}",
                     Email = details.Email

                 })
                 .ToListAsync();

            return allCustomersDetails;
        }


        public async Task<CustomerEditDetails> EditCustomerDetailsByIdAsync(string id)
        {
            var customerFromDb = await this.customerRepository
                .All()
                .FirstOrDefaultAsync(customer => customer.Id == id);

            var customerDetails = new CustomerEditDetails
            {
                Id = customerFromDb.Id,
                FirstName = customerFromDb.FirstName,
                LastName = customerFromDb.LastName,
                Email = customerFromDb.Email,
                PhoneNumber = customerFromDb.PhoneNumber
            };

            return customerDetails;
        }

        public async Task<bool> UpdateCustomerByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber)
        {
            try
            {
                var customerFromDb = await this.customerRepository
                    .All()
                    .FirstOrDefaultAsync(customer => customer.Id == id);

                customerFromDb.FirstName = firstName;
                customerFromDb.LastName = lastName;
                customerFromDb.Email = email;
                customerFromDb.PhoneNumber = phonenumber;

                await this.customerRepository.UpdateAsync(customerFromDb);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<int> Delete(string id)
        {
            try
            {
                var cutomerFromDb =  this.customerRepository.All().FirstOrDefault(customer => customer.Id == id);
                return await this.customerRepository.DeleteAsync(cutomerFromDb);
            }
            catch (Exception ms)
            {
                throw new InvalidOperationException("Invalid Delete Comand", ms.InnerException);
            }

        }
    }
}
