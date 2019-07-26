using GarageManager.App.Models.BindingModels;
using GarageManager.App.Models.ViewModels.Car;
using GarageManager.App.Models.ViewModels.Customer;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.Admin.Controllers
{
    public class CarsController : BaseAdminController
    {
        private readonly ICarServices carService;
        private readonly IModelServices modelService;
        private readonly IFuelTypeServices fuelTypeService;
        private readonly ITransmissionTypesServices transmissionTypeService;

        

        public CarsController(
            ICarServices carService,
            IManufacturerServices manufacturerService,
            IModelServices modelService,
            IFuelTypeServices fuelTypeService,
            ITransmissionTypesServices transmissionTypeService,
            IDepartmentServices departmentService
            )
        {
            this.carService = carService;
            this.modelService = modelService;
            this.fuelTypeService = fuelTypeService;
            this.transmissionTypeService = transmissionTypeService;
        }

        [HttpGet("/Admin/Cars/Create/{Id}")]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarBindingModel carBVM)
        {
            if (carBVM.CustomerId == null)
            {
                return this.View(carBVM);
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction($"/Admin/Cars/Create/{carBVM.CustomerId}");
            }

            var result = await this.carService.CreateAsync<Car>
                (
                carBVM.CustomerId,
                carBVM.Vin,
                carBVM.RegistrationPlate,
                carBVM.ManufacturerId,
                carBVM.ModelName,
                carBVM.Кilometers,
                carBVM.ManufacturedOn,
                carBVM.EngineModel,
                carBVM.EngineHorsePower,
                carBVM.FuelTypeId,
                carBVM.TransmissionId
                );
           
            return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{carBVM.CustomerId}");

        }

       

        public async Task<IActionResult> Edit(string id)
        {
            var allFuelTypes = default(IEnumerable<FuelType>);
            var allTransmissionTypes = default(IEnumerable<TransmissionType>);
            var allTasks = new List<Task>();

            allTasks.Add(Task.Run(async () =>
            {
                allFuelTypes = (await this.fuelTypeService.GetAllTypesAsync())
                                                            .OrderBy(fuel => fuel.Type);
            }));

            allTasks.Add(Task.Run(async () =>
            {
                allTransmissionTypes = (await this.transmissionTypeService.GetAllTypesAsync())
                                                                          .OrderBy(transmission => transmission.Type);
            }));

            await Task.WhenAll(allTasks);

            var carData = await this.carService.GetDetailsByIdAsync(id);
            var model = new EditCarViewModel
            {
                Id = carData.Id,
                CustomerId = carData.CustomerId,
                Vin = carData.Vin,
                Make = carData.Make,
                Model = carData.Model,
                YearOfManufacturing = carData.ManufacturedOn,
                RegistrationPlate = carData.RegistrationPlate,
                EngineModel = carData.EngineModel,
                EngineHorsePower = carData.EngineHorsePower,
                Кilometers = carData.Кilometers,
                FuelTypeId = allFuelTypes.FirstOrDefault(ft => ft.Type == carData.FuelType).Id,
                FuelTypes = allFuelTypes.Select(ft => new SelectListItem(ft.Type, ft.Id)),
                TransmissionId = allTransmissionTypes.First(tr => tr.Type == carData.Transmission).Id,
                Transmissions = allTransmissionTypes.Select(tr => new SelectListItem(tr.Type, tr.Id))


            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCarBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect($"/Admin/Cars/Edit/{model.Id}");
            }

            try
            {
                await this.carService.UpdateCarByIdAsync(
                 model.Id,
                 model.RegistrationPlate,
                 model.Кilometers,
                 model.YearOfManufacturing,
                 model.EngineModel,
                 model.EngineHorsePower,
                 model.FuelTypeId,
                 model.TransmissionId
                 );
            }
            catch (System.Exception)
            {
                return this.Redirect($"/Admin/Cars/Edit/{model.Id}");
            }

            return this.Redirect($"/Employees/Cars/Details/{model.Id}");
        }

        public async Task<IActionResult> Delete(string carId, string customerId)
        {
           await this.carService.HardDeleteAsync(carId);

            return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{customerId}");
        }


        public async Task<IActionResult> AllCarsByCustomerId(string id)
        {
            var result = new CustomerCarViewModel()
            {
                CustomerId = id
            };

            result.CustomerCars = (await this.carService.GetAllCarsByCustomerIdAsync(result.CustomerId))
                .Select(car => new CustomerCarDetailsViewModel
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    RegistrationPlate = car.RegistrationPlate,
                    IsInService = car.IsInService
                }).ToList();

            return View(result);
        }

        public async Task<IActionResult> CompletedCars()
        {
            var model = (await this.carService.CompletedCarsList())
                .Select(car => new CompletedCarList
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    RegiserPlate = car.RegisterPlate
                }).ToList();

            return this.View(model);
        }

        

        public async Task<JsonResult> AllModels(string id)
        {

            var models = (await this.modelService.GetAllByMakeIdAsync(id)).OrderBy(model => model);

            var result = Json(new SelectList(models));
            return result;
        }

      
    }
}
