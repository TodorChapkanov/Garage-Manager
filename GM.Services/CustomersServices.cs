using GM.DAL.Contracts;
using GM.Domain;
using GM.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM.Services
{
   
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerServices( ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task Create(string firstName, string lastName, string email, string phoneNumber)
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

        public async Task<ICollection<GMUser>> GetAll()
        {
            var result =  await this.customerRepository.All();
            return result;
        }
    }
}
