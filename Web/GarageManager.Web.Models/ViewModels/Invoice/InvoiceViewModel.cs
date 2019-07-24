using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Web.Models.ViewModels.Invoice
{
   public  class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            this.Services = new List<InvoiceServiceViewModel>();
        }
        public string  FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Date { get; set; }

        public IList<InvoiceServiceViewModel> Services { get; set; }

        public decimal TotalCost { get; set; }
    }
}
