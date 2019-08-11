using AutoMapper;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Part;
using GarageManager.Services.Models.Repair;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Services.Models.Invoice
{
    public class InvoiceDetails : IMapFrom<Domain.Car>
    {
        public InvoiceDetails()
        {
            this.Parts = new HashSet<InvoicePartDetails>();
            this.Repairs = new HashSet<InvoiceRepairDetails>();
        }
        public string CustomerFullName { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public IEnumerable<InvoicePartDetails> Parts { get; set; }

        public IEnumerable<InvoiceRepairDetails> Repairs { get; set; }

        public decimal TotalCost => Parts.Sum(totalCost => totalCost.TotalCost) + Repairs.Sum(repair => repair.TotalCost);

       
    }
}
