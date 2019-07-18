using GarageManager.App.Models.BindingModels.Part;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Employees.Controllers
{
    public class PartsController : BaseController
    {
        private readonly IPartsServices partsService;

        public PartsController(IPartsServices partsService)
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

            var carId = await this.partsService.CreatePart(model.CarId, model.Name, model.Number, model.Price);
            return this.Redirect($"/Employee/Cars/ServiceDetails/{carId}");
        }
    }
}
