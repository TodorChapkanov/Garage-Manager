using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace GarageManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService employeesService;

        public HomeController(IEmployeeService employeesService)
        {
            this.employeesService = employeesService;
        }


        public IActionResult Index()
        {
            if (User.IsInRole(RoleConstants.EmployeeRoleName))
            {
                var employeeId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var departmentId = this.employeesService.GetEmployeeDepartmentIdByEmployeeId(employeeId);
                return this.Redirect($"/Employees/Departments/CarsInDepartment/{departmentId}");
            }
            TempData["IsAnyEmployee"] = this.employeesService.IsAnyEmployee();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Forbiden()
        {
            return this.View();
        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
}
