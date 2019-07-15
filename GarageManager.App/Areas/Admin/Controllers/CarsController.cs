using GarageManager.App.Areas.Admin.BindingViewModels;
using GarageManager.App.Areas.Admin.ViewModels.Car;
using GarageManager.Areas.Admin.BindingViewModels;
using GarageManager.Areas.Admin.Controllers;
using GarageManager.Areas.Admin.ViewModels;
using GarageManager.Domain;
using GarageManager.Services;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.User.Controllers
{
    public class CarsController : BaseAdminController
    {
        private readonly ICarServices carService;
        private readonly IManufacturerServices manufacturerService;
        private readonly IModelServices modelService;
        private readonly IFuelTypeServices fuelTypeService;
        private readonly ITransmissionTypeServices transmissionTypeService;
        private readonly IDepartmentServices departmentService;

        //TODO Bind DaeTime to Year Adn Month

        public CarsController(
            ICarServices carService,
            IManufacturerServices manufacturerService,
            IModelServices modelService,
            IFuelTypeServices fuelTypeService,
            ITransmissionTypeServices transmissionTypeService,
            IDepartmentServices departmentService
            )
        {
            this.carService = carService;
            this.manufacturerService = manufacturerService;
            this.modelService = modelService;
            this.fuelTypeService = fuelTypeService;
            this.transmissionTypeService = transmissionTypeService;
            this.departmentService = departmentService;
        }

        public async Task<IActionResult> Create(string id)
        {
            var allManufacturers = default(IEnumerable<VehicleManufacturer>);
            var allFuelTypes = default(IEnumerable<FuelType>);
            var allTransmissionType = default(IEnumerable<TransmissionType>);
            var allTasks = new List<Task>();

            allTasks.Add(Task.Run(async () =>
            {
                allManufacturers = (await this.manufacturerService.GetAllAsync())
                                                                    .OrderBy(make => make.Name);
            }));

            allTasks.Add(Task.Run(async () =>
            {
                allFuelTypes = (await this.fuelTypeService.GetAllTypesAsync())
                                                            .OrderBy(fuel => fuel.Type);
            }));

            allTasks.Add(Task.Run(async () =>
            {
                allTransmissionType = (await this.transmissionTypeService.GetAllTypesAsync())
                                                                          .OrderBy(transmission => transmission.Type);
            }));

            await Task.WhenAll(allTasks);
            var model = new CreateCarViewModel
            {
                CustomerId = id,
                AllManufacturers = allManufacturers.Select(m => new SelectListItem(m.Name, m.Id)),
                FuelTypes = allFuelTypes.Select(ft => new SelectListItem(ft.Type, ft.Id)),
                Transmissions = allTransmissionType.Select(tr => new SelectListItem(tr.Type, tr.Id))
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarBindingViewModel carBVM)
        {
            if (carBVM.Id == null)
            {
                return this.Redirect($"/Admin/Cars/AllCarsById/{carBVM.Id}");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction($"/Admin/Cars/Create/{carBVM.Id}");
            }

            var result = await this.carService.CreateAsync<Car>
                (
                carBVM.Id,
                carBVM.Vin,
                carBVM.RegistrationPlate,
                carBVM.ManufacturerId,
                carBVM.ModelName,
                carBVM.Кilometers,
                carBVM.YearOfManufacture,
                carBVM.EngineModel,
                carBVM.EngineHorsePower,
                carBVM.FuelTypeId,
                carBVM.TransmissionId
                );

            return this.Redirect($"/Admin/Cars/AllCarsById/{carBVM.Id}");

        }

        public async Task<IActionResult> Details(string id)
        {
            var result = await this.carService.GetDetailsByIdAsync(id);
            var model = new CarDetailsViewModel
            {
                Id = result.Id,
                Make = result.Make,
                Model = result.Model,
                RegistrationPlate = result.RegistrationPlate,
                Vin = result.Vin,
                ManufacturedOn = result.ManufacturedOn,
                Кilometers = result.Кilometers,
                EngineModel = result.EngineModel,
                EngineHorsePower = result.EngineHorsePower,
                FuelType = result.FuelType,
                Transmission = result.Transmission
            };

            return this.View(model);
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

            return this.Redirect($"/Admin/Cars/Details/{model.Id}");
        }


        public async Task<IActionResult> AllCarsById(string id)
        {
            var result = new CustomerCarViewModel()
            {
                CustomerId = id
            };

            result.CustomerCars = (await this.carService.GetAllByCustomerIdAsync(result.CustomerId))
                .Select(car => new CustomerCarDetailsViewModel
                {
                    Id = car.Id,
                    Make = car.Manufacturer.Name,
                    Model = car.Model.Name,
                    RegistrationPlate = car.RegistrationPlate
                }).ToList();
            //TODO beautify View

            return View(result);
        }

        public async Task<IActionResult> Service()
        {
            var model = new AddToServiceViewModel
            {
                Departments = (await this.departmentService.AllDepartments())
                .Select(department => new SelectListItem
                {
                    Text = department.Name,
                    Value = department.Id
                }).ToList()
            };



            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Service(CarAddToServiceBindingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["description"] = model.Description;
                return this.LocalRedirect("/Admin/Cars/Service");
            }
            
             await this.carService.AddToService(model.Id, model.Description, model.DepartmentId);

            return this.Redirect($"/Admin/Cars/Details/{model.Id}");
        }

        public async Task<JsonResult> AllModels(string id)
        {

            var models = (await this.modelService.GetAllByMakeIdAsync(id)).OrderBy(model => model);

            var result = Json(new SelectList(models));
            return result;
        }
    }
}
