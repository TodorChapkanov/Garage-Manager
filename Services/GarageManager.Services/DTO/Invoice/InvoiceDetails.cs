using GarageManager.Services.DTO.Part;
using GarageManager.Services.DTO.Repair;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Services.DTO.Invoice
{
    public class InvoiceDetails
    {
        public InvoiceDetails()
        {
            this.Parts = new HashSet<InvoicePartDetails>();
            this.Repairs = new HashSet<InvoiceRepairDetails>();
        }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IEnumerable<InvoicePartDetails> Parts { get; set; }

        public IEnumerable<InvoiceRepairDetails> Repairs { get; set; }

        public decimal TotalCost => Parts.Sum(totalCost => totalCost.TotalCost) + Repairs.Sum(repair => repair.TotalCost);
    }
}
