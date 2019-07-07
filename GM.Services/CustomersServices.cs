using GM.DAL.Contracts;
using GM.Data;
using GM.Domain;
using GM.Services.Contracts;
using GM.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GM.Services
{
   
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository customerRepository;
        private readonly GMDbContext context;

        public CustomerServices( ICustomerRepository customerRepository, GMDbContext context)
        {
            this.customerRepository = customerRepository;
            this.context = context;
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

        public  Task<List<Customer>> GetAll()
        {
            var result =  this.customerRepository.All().ToListAsync();
            return result;
        }

        public  Task<List<CustomerDetail>> GetAllDetails()
        {
           
           var result =  this.customerRepository.GetAll()
                .Select(details => new CustomerDetail
                {
                    Id = details.Id,
                    FullName = $"{details.FirstName} {details.LastName}"
                })
                .ToListAsync();

            return result;
        }

        //TODO IMPLEMENT SEEDER

      /*  public  void SeedDate()
        {
            var value = File.ReadAllLines(@"C:\Users\User\Desktop\New Text Document.txt");
            
            foreach (var model in value)
            {
                var split = model.Split(new[] { ' ', '\t' });
                var models = string.Empty;
                var make = string.Empty;
                if (split.Length>= 3)
                {
                    make = split[0]+ " " + split[1];
                      models = split[2];
                }
                else
                {
                     make = split[0];
                     models = split[1];
                }

                try
                {
                    var makeId = this.context.VehicleManufacturers.First(m => m.Name == make);
                    this.context.VehicleModels.Add(new VehicleModel { Name = models, ManufactirerId = makeId.Id });

                }
                catch (Exception)
                {

                }
                
            }

            context.SaveChanges();
        }*/
    }
}
