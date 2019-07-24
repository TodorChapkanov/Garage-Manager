using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO.Repair
{
    public class InvoiceRepairDetails
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public decimal TotalCost { get; set; }
    }
}
