using GarageManager.App.Models.BindingModels.RepairService;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels.RepairService;
using GarageManager.Web.Models.ViewModels.Repair;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Employees.Controllers
{
    public class RepairsController : BaseController
    {
        private readonly IRepairsServices repairsService;

        public RepairsController(IRepairsServices repairsService)
        {
            this.repairsService = repairsService;
        }
        public IActionResult AddRepairService()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRepairService(RepairCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var carId = await this.repairsService.CreateRepairService(model.CarId, model.Description, model.Hours, model.PricePerHour);
            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }

        public async Task<IActionResult> Edit(string id, string carId)
        {
            var partFromDb = await this.repairsService.GetEditDetailsByIdAsync(id);
            var partModel = new RepairEditViewModel
            {
                Id = partFromDb.Id,
                CarId = carId,
                Description = partFromDb.Description,
                PricePerHour = partFromDb.PricePerHour,
                Hours = partFromDb.Hours,
                IsFinished = partFromDb.IsFinished
            };

            return this.View(partModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RepairEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Home/Index");
            }

           await this.repairsService.UpdatePartByIdAsync(
                model.Id,
                model.Description,
                model.Hours,
                model.PricePerHour,
                model.IsFinished);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{model.CarId}");
        }
    }
}
