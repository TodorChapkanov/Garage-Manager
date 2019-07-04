using GarageManager.Areas.Admin.Controllers.BindingViewModels;
using GM.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GarageManager.Areas.User.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerServices services;

        public CustomersController(ICustomerServices services)
        {
            this.services = services;
        }
        public IActionResult Create()
        {
            return this.View();
            //TODO Beutife Views
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create(CustomerCreateBVM model)
        {
            if (!ModelState.IsValid)
            {
                return await this.Create(model);
            }
            await this.services.Create(model.FirstName, model.LastName, model.Email, model.PhoneNumber);
            return this.LocalRedirect("All");
        }

        public IActionResult All()
        {
            return null;
        }
    }
}
