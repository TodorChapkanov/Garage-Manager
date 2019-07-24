using GarageManager.App.Models.BindingModels;
using GarageManager.App.Models.ViewModels.Customer;
using GarageManager.Areas.Admin.Controllers;
using GarageManager.Extensions.PDFConverter.HtmlToPDF;
using GarageManager.Extensions.PDFConverter.ViewRender;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Invoice;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System;

namespace GarageManager.Areas.User.Controllers
{
    public class CustomersController : BaseAdminController
    {
        private readonly ICustomerServices customerService;
        private readonly ICarServices carService;
        private readonly IInvoiceServices invoiseService;
        private readonly IViewRenderService viewRenderService;
        private readonly IHtmlToPdfConverter htmlToPdfConverter;
        private readonly IHostingEnvironment environment;

        public IViewRenderService ViewRenderService { get; }

        public CustomersController(ICustomerServices customerService,
            ICarServices carService,
            IInvoiceServices invoiseService,
            IViewRenderService viewRenderService,
    IHtmlToPdfConverter htmlToPdfConverter,
    IHostingEnvironment environment)
        {
            this.customerService = customerService;
            this.carService = carService;
            this.invoiseService = invoiseService;
            this.viewRenderService = viewRenderService;
            this.htmlToPdfConverter = htmlToPdfConverter;
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerCreateBindingModel model)
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
            var result = (await this.customerService.GetAllCustomersDetailsAsync())
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
            var customerFromDb = await this.customerService.EditCustomerDetailsByIdAsync(id);
            var model = new CustomerDetailsViewModel
            {
                Id = customerFromDb.Id,
                FirstName = customerFromDb.FirstName,
                LastName = customerFromDb.LastName,
                Email = customerFromDb.Email,
                PhoneNumber = customerFromDb.PhoneNumber
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

            if (result == default)
            {
                return this.Redirect($"/Admin/Customers/Edit/{model.Id}");
            }

            var redirect = this.Redirect($"/Admin/Customers/Details/{model.Id}");

            return redirect;
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.customerService.DeleteAsync(id);
            return this.Redirect("/Admin/Customers/AllCustomers");
        }

        public async Task<IActionResult> Invoice(string id)
        {
            var invoiceFromDb = await this.invoiseService.GetInvoiceDetailsByCarId(id);
            var invoiceModel = new InvoiceViewModel
            {
                FullName = invoiceFromDb.FullName,
                Email = invoiceFromDb.Email,
                PhoneNumber = invoiceFromDb.PhoneNumber,
                TotalCost = invoiceFromDb.TotalCost,
                Date = DateTime.UtcNow
            };

            invoiceFromDb.Parts.ToList().ForEach(part => invoiceModel.Services.Add(new InvoiceServiceViewModel
            {
                Name = part.Name,
                Price = part.Price,
                Quantity = part.Quantity,
                TotalCost = part.TotalCost
            }));

            invoiceFromDb.Repairs.ToList().ForEach(repair => invoiceModel.Services.Add(new InvoiceServiceViewModel
            {
                Name = repair.Description,
                Price = (decimal)repair.Hours,
                Quantity = repair.PricePerHour,
                TotalCost = repair.TotalCost
            }));

         return await this.GetPdf(invoiceModel);

            return this.View(invoiceModel);
        }
        public async Task<IActionResult> GetPdf( InvoiceViewModel model)
        {
            
            var htmlData = await this.viewRenderService.RenderToStringAsync("~/Views/Invoice.cshtml", model);
            var fileContents = this.htmlToPdfConverter.Convert(this.environment.ContentRootPath, htmlData, Extensions.PDFConverter.Enums.FormatType.a4, Extensions.PDFConverter.Enums.OrientationType.landscape);
            return this.File(fileContents, "application/pdf");
        }

        public async Task<IActionResult> CompleteTheOrder(string id)
        {
            var customerId = await this.carService.CompleteTheOrderByCarId(id);
            return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{customerId}");
        }
    }
}
