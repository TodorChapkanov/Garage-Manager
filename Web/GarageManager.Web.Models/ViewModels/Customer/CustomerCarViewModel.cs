using GarageManager.Web.Models.ViewModels.Car;
using GarageManager.Web.Models.ViewModels.Page;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class CustomerCarViewModel
    {
       
        public string CustomerId { get; set; }

        public bool IsInService { get; set; }

        public string SearchTerm { get; set; }

        public PaginatedList<CustomerCarDetailsViewModel> CustomerCars { get; set; }
    }
}
