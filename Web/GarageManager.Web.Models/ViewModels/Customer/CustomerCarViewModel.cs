using GarageManager.Web.Models.ViewModels.Car;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class CustomerCarViewModel
    {
        public CustomerCarViewModel()
        {
            this.CustomerCars = new List<CustomerCarDetailsViewModel>();
        }
        public string CustomerId { get; set; }

        public bool IsInService { get; set; }

        public ICollection<CustomerCarDetailsViewModel> CustomerCars { get; set; }
    }
}
