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

    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IDeletableEntityRepository<Customer> customerRepository;
        private readonly ICarService carService;

        public CustomerService(IDeletableEntityRepository<Customer> customerRepository, ICarService carService)
        {
            this.customerRepository = customerRepository;
            this.carService = carService;
        }

        public async Task<int> CreateAsync(string firstName, string lastName, string email, string phoneNumber)
        {
            try
            {
                var customer = new Customer()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };

                this.ValidateEntityState(customer);
                await this.customerRepository.CreateAsync(customer);
                return await this.customerRepository.SavaChangesAsync();
            }
            catch 
            {
                return default(int);
            }
            

          
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


        public async Task<CustomerEditDetails> GetCustomerDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
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
            catch
            {
                return null;
            }
        }

        public async Task<int> UpdateCustomerByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber)
        {
            try
            {
                this.ValidateNullOrEmptyString(id, firstName, lastName, email, phonenumber);

                var customerFromDb = await this.customerRepository
                    .All()
                    .FirstOrDefaultAsync(customer => customer.Id == id);

                customerFromDb.FirstName = firstName;
                customerFromDb.LastName = lastName;
                customerFromDb.Email = email;
                customerFromDb.PhoneNumber = phonenumber;

                this.customerRepository.Update(customerFromDb);
                return await this.customerRepository.SavaChangesAsync();
            }
            catch 
            {
                return default(int);
            }

        }

        public async Task<int> DeleteAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);

                var customerFromDb = this.customerRepository.All()
            .Include(customer => customer.Cars)
            .FirstOrDefault(customer => customer.Id == id);

                customerFromDb
                     .Cars
                     .ToList()
                     .ForEach(car => carService.HardDeleteAsync(car.Id).GetAwaiter().GetResult());

                this.customerRepository.SoftDelete(customerFromDb);
                return await this.customerRepository.SavaChangesAsync();
            }
            catch 
            {
                return default(int);
            }
            

        }
    }
}
