using GarageManager.Models;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GarageManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeesServices employeesService;

        public HomeController(IEmployeesServices employeesService)
        {
            this.employeesService = employeesService;
        }

       
        public IActionResult Index()
        {
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
