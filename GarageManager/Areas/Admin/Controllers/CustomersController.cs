using GarageManager.Areas.Admin.BindingViewModels;
using GarageManager.Areas.Admin.Controllers;
using GarageManager.Areas.Admin.ViewModels;
using GM.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.User.Controllers
{
    public class CustomersController : BaseAdminController
    {
        private readonly ICustomerServices services;

        public CustomersController(ICustomerServices services)
        {
            this.services = services;
        }

        [HttpGet]
        public IActionResult Create()
        {
          
            return this.View();
            //TODO Beutife Views

           
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            await this.services.Create(model.FirstName, model.LastName, model.Email, model.PhoneNumber);

            return this.Redirect("AllCustomers");
       }


        public IActionResult AllCustomers()
        {
            var result = this.services.GetAllDetails().Result.Select(details => new AllCustomersDetails { Id = details.Id, FullName = details.FullName}).ToList();

            return this.View(result);
        }
    }
}
