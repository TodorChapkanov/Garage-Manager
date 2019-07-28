using GarageManager.Web.Models.BindingModels.Part;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Part;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class PartsController : BaseController
    {
        private readonly IPartsService partsService;

        public PartsController(IPartsService partsService)
        {
            this.partsService = partsService;
        }

        public IActionResult AddPart()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(PartCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var carId = await this.partsService
                .CreatePartAsync(
                model.CarId,
                model.Name,
                model.Number,
                model.Price,
                model.Quantity);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }

        public async Task<IActionResult> Edit(string id, string carId)
        {
            var partFromDb = await this.partsService.GetEditDetailsByIdAsync(id);
            var partModel = new PartEditViewModel
            {
                Id = partFromDb.Id,
                CarId = carId,
                Name = partFromDb.Name,
                Number = partFromDb.Number,
                Price = partFromDb.Price,
                Quantity = partFromDb.Quantity
            };

            return this.View(partModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Home/Index");
            }

          await  this.partsService.UpdatePartByIdAsync(
                model.Id,
                model.Name, 
                model.Number,
                model.Price,
                model.Quantity);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{model.CarId}");
        }

        public async Task<IActionResult> Delete(string carId, string partId)
        {
          var serviceId = await this.partsService.HardDeleteAsync(partId);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }
    }
}
