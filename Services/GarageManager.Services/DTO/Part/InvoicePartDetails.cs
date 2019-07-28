using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO.Part
{
    public class InvoicePartDetails
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
    }
}
