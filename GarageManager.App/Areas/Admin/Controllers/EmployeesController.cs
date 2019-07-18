using GarageManager.Areas.Admin.Controllers;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace GarageManager.App.Areas.Admin.Controllers
{
    public class EmployeesController : BaseAdminController
    {
        private readonly IEmployeesServices employeesService;

        public EmployeesController(IEmployeesServices employeesService)
        {
            this.employeesService = employeesService;
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }
            return null;
        }

        public IActionResult Edit()
        {
            return null;
        }

        [HttpPost]
        public IActionResult Edit(string id)
        {
            return null;
        }

        public IActionResult Details()
        {
            return null;
        }

        public IActionResult Delete()
        {
            return null;
        }
    }
}
