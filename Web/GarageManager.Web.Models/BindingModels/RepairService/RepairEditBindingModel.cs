using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Web.Models.BindingModels.RepairService
{
   public class RepairEditBindingModel
    {
        public string Id { get; set; }

        public string CarId { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }
    }
}
