using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
   
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<Customer> customerRepository;

        public CustomerServices( IRepository<Customer> customerRepository)
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

        public  Task<List<Customer>> GetAllAsync()
        {
            var allCustomers =  this.customerRepository.All().ToListAsync();
            return allCustomers;
        }

       

        public  Task<List<CustomerDetail>> GetAllCustomersDetailsAsync()
        {
           
           var allCustomersDetails =  this.customerRepository.All()
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
            var customerFromDb = (await this.customerRepository.GetByIdAsync(id));
              var customerDetails = new CustomerEditDetails
                { 
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
                var customerFromDb = await this.customerRepository.GetByIdAsync(id);

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
