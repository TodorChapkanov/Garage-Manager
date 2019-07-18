using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Models.BindingModels.RepairService
{
    public class RepairCreateBindingModel
    {
        [BindProperty(Name = "id")]
        public string CarId { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }
    }
}
