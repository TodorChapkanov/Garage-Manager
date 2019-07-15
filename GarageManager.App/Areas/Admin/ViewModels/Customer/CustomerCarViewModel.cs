using System.Collections.Generic;

namespace GarageManager.Areas.Admin.ViewModels
{
    public class CustomerCarViewModel
    {
        public CustomerCarViewModel()
        {
            this.CustomerCars = new List<CustomerCarDetailsViewModel>();
        }
        public string CustomerId { get; set; }

        public ICollection<CustomerCarDetailsViewModel> CustomerCars { get; set; }
    }
}
