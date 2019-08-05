using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels;
using GarageManager.Web.Models.ViewModels.Car;
using GarageManager.Web.Models.ViewModels.Customer;
using GarageManager.Web.Models.ViewModels.FuelType;
using GarageManager.Web.Models.ViewModels.TransmissionType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Create(CreateCarBindingModel carBVM)
        {
            if (!ModelState.IsValid)
            {
               return RedirectToAction($"/Admin/Cars/Create/{carBVM.CustomerId}");
            }

            var reault = await this.carService.CreateAsync
                (
                carBVM.CustomerId,
                carBVM.Vin,
                carBVM.RegistrationPlate,
                carBVM.ManufacturerId,
                carBVM.ModelName,
                carBVM.Кilometers,
                carBVM.YearOfManufacturing,
                carBVM.EngineModel,
                carBVM.EngineHorsePower,
                carBVM.FuelTypeId,
                carBVM.TransmissionId
                );

            if (reault)
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.CarCreatedSuccessfull, carBVM.RegistrationPlate),
                    NotificationType.Success);
                return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{carBVM.CustomerId}");
            }


            this.ShowNotification(string.Format(
                    NotificationMessages.CarCreateFail),
                    NotificationType.Warning);

            return this.View(carBVM);
        }

       

        public async Task<IActionResult> Edit(string id)
        {
            var allFuelTypes = default(IEnumerable<FuelTypeDetails>);
            var allTransmissionTypes = default(IEnumerable<TransmissionTypeDetails>);
            var allTasks = new List<Task>();

            allTasks.Add(Task.Run(async () =>
            {
                allFuelTypes = (await this.fuelTypeService.GetAllTypesAsync())
                    .Select(ft => new FuelTypeDetails
                      {
                        Id = ft.Id,
                        Type = ft.Type
                      })
                    .OrderBy(fuel => fuel.Type);
            }));

            allTasks.Add(Task.Run(async () =>
            {
                allTransmissionTypes = (await this.transmissionTypeService.GetAllTypesAsync())
                .Select(tt => new TransmissionTypeDetails
                {
                    Id = tt.Id,
                    Type = tt.Type
                })
                .OrderBy(transmission => transmission.Type);
            }));

            await Task.WhenAll(allTasks);

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
            //TODO Add dropdown and rename yearOfManyfacturing for car year
              var result = await this.carService.UpdateCarByIdAsync(
                 model.Id,
                 model.RegistrationPlate,
                 model.Кilometers,
                 model.YearOfManufacturing,
                 model.EngineModel,
                 model.EngineHorsePower,
                 model.FuelTypeId,
                 model.TransmissionId
                 );
            if (result != default(int))
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.CarUpdatedSuccessfull),
                    NotificationType.Success);
                return this.Redirect($"/Employees/Cars/Details/{model.Id}");
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CarEditFail),
                    NotificationType.Warning);
            return this.View(model.Id);
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
                    NotificationMessages.CarNotExist),
                    NotificationType.Error);
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CarDeletedSuccessfull),
                    NotificationType.Warning);

            return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{customerId}");
        }


        public async Task<IActionResult> AllCarsByCustomerId(string id)
        {
           
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
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

            if (model.CustomerCars == null)
            {
                this.ShowNotification(string.Format(
                       NotificationMessages.InvalidOperation),
                       NotificationType.Error);

                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }
            return View(model);
        }

        public async Task<IActionResult> CompletedCars()
        {
            var model = (await this.carService.CompletedCarsListAsync())
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
            try
            {
                var models = (await this.modelService.GetAllByMakeIdAsync(id)).OrderBy(model => model);

                var result = Json(new SelectList(models));
                return result;
            }
            catch 
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);

                this.Redirect(RedirectUrl_s.HomeIndex);
            }

            return null;
        }
    }
}
