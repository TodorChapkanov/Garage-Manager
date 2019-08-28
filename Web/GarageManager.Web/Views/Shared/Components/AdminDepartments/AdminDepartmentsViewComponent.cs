using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Contracts;
using GarageManager.Web.Views.Shared.Components.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GarageManager.Web.Views.Shared.Components.AdminDepartments
{
    public class AdminDepartmentsViewComponent : ViewComponent
    {
        private readonly IDepartmentService departmentService;

        public AdminDepartmentsViewComponent(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public IViewComponentResult Invoke()
        {
            var result = this.departmentService.AllDepartmentsAsync()
                .GetAwaiter(
                ).GetResult()
                .Where(department => department.Name != DepartmentConstants.FacilitiesManagement)
                .ToList();

            var model = result.Select(department => new AdminDepartment
            {
                Id = department.Id,
                Name = department.Name
            });

            return this.View(WebConstants.ViewComponentDefault, model);
        }
    }
}
