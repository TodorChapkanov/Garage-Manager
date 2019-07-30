using GarageManager.Web.Models.BindingModels;
using GarageManager.Web.Models.ViewModels.Car;
using GarageManager.Web.Models.ViewModels.Customer;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.Common.Notification;
using GarageManager.Web.Infrastructure.Filters;
using System;

namespace GarageManager.Web.Areas.Admin.Controllers
{
    public class CarsController : BaseAdminController
    {
        private readonly ICarService carService;
        private readonly IModelService modelService;
        private readonly IFuelTypeService fuelTypeService;
        private readonly ITransmissionTypesService transmissionTypeService;

        

        public CarsController(
            ICarService carService,
            IManufacturerService manufacturerService,
            IModelService modelService,
            IFuelTypeService fuelTypeService,
            ITransmissionTypesService transmissionTypeService,
            IDepartmentService departmentService
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
        [ValidateModelState]
        public async Task<IActionResult> Create(CreateCarBindingModel carBVM)
        {
            if (!ModelState.IsValid)
            {
               return RedirectToAction($"/Admin/Cars/Create/{carBVM.CustomerId}");
            }

            var model = await this.carService.CreateAsync<Car>
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

            this.ShowNotification(string.Format(
                    NotificationMessages.CarCreatedSuccessfull, carBVM.RegistrationPlate),
                    NotificationType.Success);

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

            //TODO Test method with NULL
            var carData = await this.carService.GetCarDetailsByIdAsync(id);
            if (carData == null)
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);
                this.Redirect("/Admin/Customers/AllCustomers");
            }
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

            this.ShowNotification(string.Format(
                    NotificationMessages.CarUpdatedSuccessfull),
                    NotificationType.Success);

            return this.Redirect($"/Employees/Cars/Details/{model.Id}");
        }

        public async Task<IActionResult> Delete(string carId, string customerId)
        {
            try
            {
                await this.carService.HardDeleteAsync(carId);
            }
            catch (System.Exception)
            {

                this.ShowNotification(string.Format(
                    NotificationMessages.InvalidCarId),
                    NotificationType.Error);
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CarDeletedSuccessfull),
                    NotificationType.Warning);

            return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{customerId}");
        }


        public async Task<IActionResult> AllCarsByCustomerId(string id)
        {
            throw new InvalidOperationException();
            if (!this.IsValidId(id))
            {
                return this.Redirect("/Admin/Customers/AllCustomers");
            }
            var model = new CustomerCarViewModel()
            {
                CustomerId = id
            };
           
            model.CustomerCars = (await this.carService.GetAllCarsByCustomerIdAsync(model.CustomerId))
                .Select(car => new CustomerCarDetailsViewModel
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    RegistrationPlate = car.RegistrationPlate,
                    IsInService = car.IsInService
                }).ToList();

            return View(model);
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
