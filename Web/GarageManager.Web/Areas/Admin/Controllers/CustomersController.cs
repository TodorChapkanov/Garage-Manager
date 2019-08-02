using GarageManager.Common;
using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Extensions.PDFConverter.HtmlToPDF;
using GarageManager.Extensions.PDFConverter.ViewRender;
using GarageManager.Services.Contracts;
using GarageManager.Web.Areas.Admin.Controllers;
using GarageManager.Web.Models.BindingModels;
using GarageManager.Web.Models.ViewModels.Customer;
using GarageManager.Web.Models.ViewModels.Invoice;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.User.Controllers
{
    public class CustomersController : BaseAdminController
    {
        private readonly ICustomerService customerService;
        private readonly ICarService carService;
        private readonly IInvoiceService invoiseService;
        private readonly IViewRenderService viewRenderService;
        private readonly IHtmlToPdfConverter htmlToPdfConverter;
        private readonly IHostingEnvironment environment;
        private readonly IDateTimeProvider dateTimeProvider;

        public IViewRenderService ViewRenderService { get; }

        public CustomersController(ICustomerService customerService,
            ICarService carService,
            IInvoiceService invoiseService,
            IViewRenderService viewRenderService,
            IHtmlToPdfConverter htmlToPdfConverter,
            IHostingEnvironment environment,
            IDateTimeProvider dateTimeProvider)
        {
            this.customerService = customerService;
            this.carService = carService;
            this.invoiseService = invoiseService;
            this.viewRenderService = viewRenderService;
            this.htmlToPdfConverter = htmlToPdfConverter;
            this.environment = environment;
            this.dateTimeProvider = dateTimeProvider;
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


            var result = await this.customerService
                 .CreateAsync(model.FirstName, model.LastName, model.Email, model.PhoneNumber);

            if (result != default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Warning);
                return this.Redirect("/Admin/Customers/AllCustomers");
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CustomerCreateSuccessfull, model.FirstName, model.LastName),
                    NotificationType.Success);
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
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }

            var customer = await this.customerService.GetCustomerDetailsByIdAsync(id);

            if (customer == null)
            {
                this.ShowNotification(NotificationMessages.CustomerNotExist,
                    NotificationType.Warning);
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }

            var result = new CustomerDetailsViewModel()
            {
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber
            };

            return this.View(result);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }

            var customerFromDb = await this.customerService.GetCustomerDetailsByIdAsync(id);
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

            if (result == default(int))
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);
                return this.Redirect($"/Admin/Customers/Edit/{model.Id}");
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CustomerEditSuccessfull),
                    NotificationType.Success);

            var redirect = this.Redirect($"/Admin/Customers/Details/{model.Id}");

            return redirect;
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }
            var result = await this.customerService.DeleteAsync(id);
            if (result != default(int))
            {
                this.ShowNotification(NotificationMessages.CustomerDeleteSuccessfull,
                NotificationType.Warning);
            }

            this.ShowNotification(NotificationMessages.InvalidOperation,
                NotificationType.Warning);


            return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
        }

        public async Task<IActionResult> Invoice(string id)
        {
            if (this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var invoiceFromDb = await this.invoiseService.GetInvoiceDetailsByCarId(id);

            if (invoiceFromDb == null)
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var invoiceModel = new InvoiceViewModel
            {
                FullName = invoiceFromDb.FullName,
                Email = invoiceFromDb.Email,
                PhoneNumber = invoiceFromDb.PhoneNumber,
                TotalCost = invoiceFromDb.TotalCost,
                Date = this.dateTimeProvider.GetDateTime()
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

        }
        public async Task<IActionResult> GetPdf(InvoiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var htmlData = await this.viewRenderService.RenderToStringAsync("~/Views/Invoice.cshtml", model);
            var fileContents = this.htmlToPdfConverter.Convert(this.environment.ContentRootPath, htmlData, Extensions.PDFConverter.Enums.FormatType.a4, Extensions.PDFConverter.Enums.OrientationType.landscape);
            return this.File(fileContents, "application/pdf");
        }

        public async Task<IActionResult> CompleteTheOrder(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect("/Admin/Customers/AllCustomers");
            }

            var customerId = await this.carService.CompleteTheOrderByCarId(id);
            if (customerId == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Warning);

                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }

            this.ShowNotification(NotificationMessages.CustomerOrderCompletedSuccessfully,
                NotificationType.Success);

            return this.Redirect($"/Admin/Cars/AllCarsByCustomerId/{customerId}");
        }
    }
}
