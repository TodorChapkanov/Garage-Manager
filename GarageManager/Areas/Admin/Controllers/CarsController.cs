
using AutoMapper;
using GarageManager.Areas.Admin.BindingViewModels;
using GarageManager.Areas.Admin.Controllers;
using GM.Services;
using GM.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.User.Controllers
{
    public class CarsController : BaseAdminController
    {
        private readonly ICarServices services;
        private readonly IManufacturerServices manufacturerServices;
        private readonly IModelServices modelServices;
        private readonly IFuelTypeServices fuelTypeServices;
        private readonly ITransmissionTypeServices transmissionTypeServices;

        public CarsController(ICarServices services, IManufacturerServices manufacturerServices, IModelServices modelServices, IFuelTypeServices fuelTypeServices, ITransmissionTypeServices transmissionTypeServices)
        {
            this.services = services;
            this.manufacturerServices = manufacturerServices;
            this.modelServices = modelServices;
            this.fuelTypeServices = fuelTypeServices;
            this.transmissionTypeServices = transmissionTypeServices;
        }

        public IActionResult Create()
        {
            var allManufacturers =  this.manufacturerServices.GetAll().ToList();
            var allFuelTypes = this.fuelTypeServices.GetAllTypes();
            var allTransmissionType = this.transmissionTypeServices.GetAllTypes();


            var model = new CreateCarViewModel
            {
                AllManufacturers = allManufacturers.Select(m => new SelectListItem(m.Name, m.Id)),
                FuelType = allFuelTypes.Select(ft => new SelectListItem(ft.Type, ft.Id)),
                Transmission = allTransmissionType.Select(tr => new SelectListItem(tr.Type, tr.Id))
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateCarBVM carBVM)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Admin/Cars/Create");
            }

            return Redirect("/Home/Index");

        }

        public JsonResult AllModels(string id)
        {

            var models = this.modelServices.GetAllByMakeId(id).GetAwaiter().GetResult();

            return Json(new SelectList(models));
        }
    }
}
