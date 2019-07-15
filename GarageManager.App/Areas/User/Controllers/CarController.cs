using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.User.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
