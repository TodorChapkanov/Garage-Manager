using GarageManager.Web.Models.ViewModels.Department;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class DepartmentsController : BaseEmployeeController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<IActionResult> CarsInDepartment(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect("/");
            }
            var result = await this.departmentService.GetDepartmentCars(id);
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

    }
}
