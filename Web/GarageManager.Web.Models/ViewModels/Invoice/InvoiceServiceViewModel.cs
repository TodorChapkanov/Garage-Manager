using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Web.Models.ViewModels.Invoice
{
    public class InvoiceServiceViewModel
    {
        public string  Name { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalCost { get; set; }
    }
}
