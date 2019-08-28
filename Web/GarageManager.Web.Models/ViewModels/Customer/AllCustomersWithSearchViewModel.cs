using GarageManager.Services.Models.Customer;
using GarageManager.Web.Models.ViewModels.Page;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class AllCustomersWithSearchViewModel
    {
        public string SearchTerm { get; set; }
        public PaginatedList<AllCustomersDetailsViewModel> Customers { get; set; }
    }
}
