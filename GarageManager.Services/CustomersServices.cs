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
        private readonly ICarServices carService;

        public CustomerServices(IDeletableEntityRepository<Customer> customerRepository, ICarServices carService)
        {
            this.customerRepository = customerRepository;
            this.carService = carService;
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

        public async Task<int> DeleteAsync(string id)
        {
            var customerFromDb = this.customerRepository.All()
            .Include(customer => customer.Cars)
            .FirstOrDefault(customer => customer.Id == id);

            //Delete asinhonus all
            customerFromDb
                 .Cars
                 .Select(async car => await carService.HardDeleteAsync(car.Id))
                 .ToList()
            .ForEach(task => task.GetAwaiter().GetResult());

            return await this.customerRepository.SoftDeleteAsync(customerFromDb);
        }
    }
}
