using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GarageManager.Web.Models.ViewModels.Invoice
{
   public  class InvoiceViewModel
    {
        public InvoiceViewModel()
        {
            this.Services = new List<InvoiceServiceViewModel>();
        }

        [Required]
        public string  FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public IList<InvoiceServiceViewModel> Services { get; set; }

        [Required]
        public decimal TotalCost { get; set; }
    }
}
