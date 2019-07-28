using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using GarageManager.Services.DTO.Invoice;
using GarageManager.Services.DTO.Part;
using GarageManager.Services.DTO.Repair;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;

        public InvoiceService( IDeletableEntityRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }
        public async Task<InvoiceDetails> GetInvoiceDetailsByCarId(string id)
        {

            var invoiceDetails = await this.carRepository
                .All()
                .Where(car => car.Id == id)
                .Include(car => car.Services)
                .Select(car => new InvoiceDetails
                {
                   FullName = car.Customer.FullName,
                   Email = car.Customer.Email,
                   PhoneNumber = car.Customer.PhoneNumber,
                   Parts = car.Services
                     .First(service => service.Id == car.CurrentServiceId)
                     .Parts
                     .Select(part => new InvoicePartDetails
                      {
                          Id = part.Id,
                          Name = part.Name,
                          Price = part.Price,
                          Quantity = part.Quantity,
                          TotalCost = part.TotalCost
                      }).ToList(),
                   Repairs = car.Services
                     .First(service => service.Id == car.CurrentServiceId)
                     .Repairs
                     .Select(repair => new InvoiceRepairDetails
                          {
                              Id = repair.Id,
                              Description = repair.Description,
                              Hours = repair.Hours,
                              PricePerHour = repair.PricePerHour,
                              TotalCost = repair.TotalCosts,
                          }).ToList()

                }).FirstOrDefaultAsync();

            return invoiceDetails;
        }
    }
}
