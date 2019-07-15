using GarageManager.Areas.Admin.BindingViewModels;
using System.Collections.Generic;

namespace GarageManager.Areas.Admin.ViewModels
{
    public class AllCustomerViewModel
    {
        public AllCustomerViewModel()
        {
            Customers = new List<AllCustomersDetailsViewModel>();
        }

        public ICollection<AllCustomersDetailsViewModel> Customers { get; set; }
    }
}
