using GarageManager.App.Models.ViewModels.Car;
using System.Collections.Generic;

namespace GarageManager.App.Models.ViewModels.Customer
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
