using GarageManager.Areas.Admin.BindingViewModels;
using System.Collections.Generic;

namespace GarageManager.Areas.Admin.ViewModels
{
    public class AllCustomers
    {
        public AllCustomers()
        {
            Customers = new List<AllCustomersDetails>();
        }

        public ICollection<AllCustomersDetails> Customers { get; set; }
    }
}
