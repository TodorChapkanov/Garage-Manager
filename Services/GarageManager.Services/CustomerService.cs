using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Customer;
using Microsoft.EntityFrameworkCore;
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
              return  await this.customerRepository.CreateAsync(customer);
                
            }
            catch 
            {
                return default(int);
            }
            

          
        }

        public Task<List<CustomerDetail>> GetAllCustomersDetailsAsync()
        {
            var allCustomersDetails =  this.customerRepository.All().To<CustomerDetail>().ToListAsync();
                /* .Select(details => new CustomerDetail
                 {
                     Id = details.Id,
                     FullName = $"{details.FirstName} {details.LastName}",
                     Email = details.Email

                 })
                 .ToListAsync();*/

            return allCustomersDetails;
        }


        public async Task<CustomerEditDetails> GetCustomerDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var customerFromDb = await this.customerRepository
                .GetEntityByKeyAsync(id);

                var customerDetails = AutoMapper.Mapper.Map<CustomerEditDetails>(customerFromDb);

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
                    .GetEntityByKeyAsync(id);

                customerFromDb.FirstName = firstName;
                customerFromDb.LastName = lastName;
                customerFromDb.Email = email;
                customerFromDb.PhoneNumber = phonenumber;

               return await this.customerRepository.Update(customerFromDb);
            }
            catch 
            {
                return default(int);
            }

        }

        public async Task<int> SoftDeleteAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);

                var customerFromDb = this.customerRepository.All()
            .FirstOrDefault(customer => customer.Id == id);

                this.customerRepository.All()
                    .Where(customer => customer.Id == id)
                    .Select(car => car.Cars.ToList())
                    .First()
                     .ForEach(car => carService.HardDeleteAsync(car.Id).GetAwaiter().GetResult());

                return await this.customerRepository.SoftDeleteAsync(customerFromDb);
            }
            catch 
            {
                return default(int);
            }
            

        }
    }
}
