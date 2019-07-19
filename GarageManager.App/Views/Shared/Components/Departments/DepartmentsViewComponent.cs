using GarageManager.App.Views.Shared.Components.Models;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Views.Shared.Components.Departments
{
    public class DepartmentsViewComponent : ViewComponent
    {
        private readonly IDepartmentServices departmentService;

        public DepartmentsViewComponent(IDepartmentServices departmentService)
        {
            this.departmentService = departmentService;
        }

        public IViewComponentResult Invoke()
        {
            var departments =  new DepartmentModel
            {
                Departments = this.departmentService
                .AllDepartmentsAsync()
                .Result
                .OrderBy(department =>department.Name)
                .Select(dep => new SelectListItem
                {
                    Text = dep.Name,
                    Value = dep.Id
                }).ToList()
            };

            return View("Default", departments);
        }
    }
  
}
