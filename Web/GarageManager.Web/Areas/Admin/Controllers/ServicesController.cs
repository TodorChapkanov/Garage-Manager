using GarageManager.Web.Areas.Admin.Controllers;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using GarageManager.Web.Models.ViewModels.ServiceIntervention;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Admin.Controllers
{
    public class ServicesController : BaseAdminController
    {
        private readonly IInterventionService interventionService;

        public ServicesController(IInterventionService interventionService)
        {
            this.interventionService = interventionService;
        }

        public async Task<IActionResult> ServiceHistoryByCarId(string id)
        {
          var model = (await this.interventionService.CarServicesHistoryAsync(id))
                .Select(service => new CarServiceHistoryViewModel
                {
                    Id = service.Id,
                    CarMake = service.CarMake,
                    CarRegistrtionPlate = service.CarRegistrtionPlate,
                    FinishedOn = service.FinishedOn,
                    Price = service.Price
                })
                .OrderByDescending(service => service.FinishedOn);

            return this.View(model);
        }

        public async Task<IActionResult> ServiceDetails(string id)
        {
            var serviceDetails = await this.interventionService.ServiceHistoryDetailsAsync(id);
            var model = new CarServiceHistoryDetailsViewModel
            {
                CarId = serviceDetails.CarId,
                Parts = serviceDetails.Parts.Select(part => new CarServiceHistoryPartDetailsViewModel
                {
                    Name = part.Name,
                    Number = part.Number,
                    Quantity = part.Quantity,
                    TotalCost = part.TotalCost
                }),
                Repairs = serviceDetails.Repairs.Select(repair => new CarServiceHistoryRepairDetailsViewModel
                {
                    Description = repair.Description,
                    EmployeeName = repair.EmployeeName,
                    Hours = repair.Hours,
                    TotalCost = repair.TotalCost
                })
            };

            return this.View(model);
        }
    }
}
