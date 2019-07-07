using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GarageManager.Models;
using GM.Data;
using GM.Domain;

namespace GarageManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly GMDbContext context;

        public HomeController(GMDbContext context)
        {
            this.context = context;
        }

       
        public IActionResult Index()
        {
         
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
