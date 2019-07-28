using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO.Repair
{
    public class ServiceHistoryRepairDetails
    {
        public string Description { get; set; }

        public string EmployeeName { get; set; }

        public decimal Hours { get; set; }

        public decimal TotalCost { get; set; }
    }
}
