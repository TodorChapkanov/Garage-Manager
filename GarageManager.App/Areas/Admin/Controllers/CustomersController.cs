using GarageManager.App.Areas.Admin.BindingViewModels;
using GarageManager.Areas.Admin.BindingViewModels;
using GarageManager.Areas.Admin.Controllers;
using GarageManager.Areas.Admin.ViewModels;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.User.Controllers
{
    public class CustomersController : BaseAdminController
    {
        private readonly ICustomerServices customerService;

        public CustomersController(ICustomerServices customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            return this.View();
            //TODO beautify View

        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateBindingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.customerService
                .CreateNewAsync(model.FirstName, model.LastName, model.Email, model.PhoneNumber);

            return this.Redirect("/Admin/Customers/AllCustomers");
       }


        public async Task<IActionResult> AllCustomers()
        {
            var result = (await  this.customerService.GetAllCustomersDetailsAsync())
                .Select(details => new AllCustomersDetailsViewModel
                {
                    Id = details.Id,
                    FullName = details.FullName,
                    Email = details.Email
                }).ToList();

            return this.View(result);
        }

        public async Task<IActionResult> Details(string id)
        {
            var customer = await this.customerService.EditCustomerDetailsByIdAsync(id);
            var result = new CustomerDetailsViewModel()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber
            };

            //TODO beautify View
            return this.View(result);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var customerDetails = await this.customerService.EditCustomerDetailsByIdAsync(id);
            var model = new CustomerDetailsViewModel
            {
                FirstName = customerDetails.FirstName,
                LastName = customerDetails.LastName,
                Email = customerDetails.Email,
                PhoneNumber = customerDetails.PhoneNumber
            };

            return this.View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCustomerBindingModel model)
        {
            var result = await this.customerService
                .UpdateCustomerByIdAsync(
                model.Id,
                model.FirstName,
                model.LastName,
                model.Email,
                model.PhoneNumber);

            if (!result)
            {
                return this.Redirect($"/Admin/Customers/Edit/{model.Id}");
            }

          var redirect =  this.Redirect($"/Admin/Customers/Details/{model.Id}");

            return redirect;
        }

       // public async Task<IActionResult> AllCars(string customerId)
       // {
       //   
       // }
    }
}
