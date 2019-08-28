using GarageManager.Common.GlobalConstant;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.Customer;
using GarageManager.Services.Models.Enums;
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

        public async Task<string> CreateAsync(string firstName, string lastName, string email, string phoneNumber)
        {
            if (this.customerRepository.All().Any(customer => customer.Email == email))
            {
                return CustomerCnstants.InvalidCustomerEmailCode;
            }
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

                return customer.Id;
                
            }
            catch 
            {
                return null;
            }
        }

        public async Task<List<CustomerDetails>> GetAllCustomersDetailsAsync(int pageNumber, string searchTerm)
        {
           
            var allCustomers = this.customerRepository
                .AllAsNoTracking()
                .OrderBy(customer => customer.FirstName)
                .ThenBy(customer => customer.LastName);
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                allCustomers = allCustomers
                    .Where(customer => customer.FullName.ToLower().Contains(searchTerm.ToLower()))
                    .OrderBy(customer => customer.FirstName).ThenBy(customer => customer.LastName);
            }

            var pageCustomers = await(base.PaginateEntitiesAsync<Customer>(
                allCustomers, 
                Enums.PaginationOrderMember.FullName,
                OrderDirection.Ascending, pageNumber, 
                PaginationConstants.ItemPerCustomerPage).Select(customer => AutoMapper.Mapper.Map<CustomerDetails>(customer))
                .ToListAsync());

             

            return pageCustomers;
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
