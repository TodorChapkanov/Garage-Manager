using GarageManager.App.Areas.Admin.BindingModels.Part;
using GarageManager.App.Areas.Admin.ViewModels.Department;
using GarageManager.App.Areas.Admin.ViewModels.Part;
using GarageManager.App.Areas.Admin.ViewModels.Repair;
using GarageManager.Areas.Admin.Controllers;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Admin.Controllers
{
    public class DepartmentsController : BaseAdminController
    {
        private readonly IDepartmentServices departmentService;
        private readonly ICarServices carService;

        public DepartmentsController(IDepartmentServices departmentService, ICarServices carService)
        {
            this.departmentService = departmentService;
            this.carService = carService;
        }
        public async Task<IActionResult> AllCars(string id)
        {
            var result = (await this.departmentService.GetDepartmentCars(id));
            var viewModel = new DepartmentCarsList
            {
                Name = result.Name,
                Cars = result.Cars.Select(car => new DepartmentCarDetails
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    RegistrationPlate = car.RegisterPlate
                }).ToList()
            };

            return this.View(viewModel);
        }

       public async Task<IActionResult> ServiceDetails(string id)
        {

            var carModel = await this.departmentService.GetCarServicesAsync(id);

            var model = new CarServicesDetailsViewModel
            {
                Make = carModel.Make,
                Model = carModel.Model,
                RegisterPlate = carModel.RegisterPlate,
                ServiceId = carModel.ServiceId,
                Parts = carModel.Parts.Select(part => new PartDetailsViewModel
                {
                    Id = part.Id,
                    Name = part.Name,
                    Number = part.Number,
                    Price = part.Price
                }),
                Repairs = carModel.Repairs.Select(repair => new RepairDetailsViewModel
                {
                    Id = repair.Id,
                    Description = repair.Description,
                    Hours = repair.Hours,
                    PricePerHour = repair.PricePerHour
                })
            };

            return this.View(model);
        }

        public IActionResult AddPart()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult AddPart(AddPartBindingModel model, string id)
        {
            if (!ModelState.IsValid)
            {

            }
            return this.View();
        }
    }
}
