using GarageManager.App.Models.BindingModels.RepairService;
using GarageManager.Services.Contracts;
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
            return this.Redirect($"/Employee/Cars/ServiceDetails/{carId}");
        }
    }
}
