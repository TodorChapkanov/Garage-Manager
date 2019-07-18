﻿using GarageManager.App.Models.ViewModels.Department;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Employees.Controllers
{
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentServices departmentService;

        public DepartmentsController(IDepartmentServices departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<IActionResult> CarsInDepartment(string id)
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

    }
}