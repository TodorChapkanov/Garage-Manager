﻿using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Customer
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
