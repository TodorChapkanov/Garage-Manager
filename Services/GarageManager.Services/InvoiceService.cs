using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Invoice;
using GarageManager.Services.Models.Part;
using GarageManager.Services.Models.Repair;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;

        public InvoiceService( IDeletableEntityRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<InvoiceDetails> GetInvoiceDetailsByCarIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);

                var invoiceDetails = await this.carRepository
               .All()
               .Where(car => car.Id == id)
               .Select(car => new InvoiceDetails
               {
                   CustomerFullName = car.Customer.FullName,
                   CustomerEmail = car.Customer.Email,
                   CustomerPhoneNumber = car.Customer.PhoneNumber,
                   Parts = car.Services
                    .First(service => service.Id == car.ServiceId)
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
                    .First(service => service.Id == car.ServiceId)
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
            catch 
            {
                return null;
            }
           
        }
    }
}
