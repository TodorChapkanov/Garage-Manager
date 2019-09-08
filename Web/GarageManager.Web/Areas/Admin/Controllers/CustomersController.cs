using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Extensions.PDFConverter.HtmlToPDF;
using GarageManager.Extensions.PDFConverter.ViewRender;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels;
using GarageManager.Web.Models.ViewModels.Customer;
using GarageManager.Web.Models.ViewModels.Invoice;
using GarageManager.Web.Models.ViewModels.Page;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Admin.Controllers
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
        
        public static int CurrentPage { get; private set; }

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

            if (result == CustomerCnstants.InvalidCustomerEmailCode)
            {
                this.ShowNotification(string.Format(NotificationMessages.InvalidCustomerEmail,model.Email),
                    NotificationType.Warning);
                return this.View(model);
            }
            if (result == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Warning);
                return this.RedirectToAction(nameof(AllCustomers));
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CustomerCreateSuccessfull, model.FirstName, model.LastName),
                    NotificationType.Success);
            return this.Redirect(string.Format(WebConstants.AdminCarsCarsByCustomerId,result));
        }


        public async Task<IActionResult> AllCustomers(string searchTerm)
        {
            var watch = new Stopwatch();
            watch.Start();
            CurrentPage = 1;
            var result = (await this.customerService.GetAllCustomersDetailsAsync(CurrentPage++, searchTerm))
                .Select(details => new AllCustomersDetailsViewModel
                {
                    Id = details.Id,
                    Email = details.Email,
                    FullName = details.FullName
                });
            var model = new AllCustomersWithSearchViewModel
            {
                SearchTerm = searchTerm,
                Customers = new PaginatedList<AllCustomersDetailsViewModel>(result)
            };
            System.Console.WriteLine(watch.Elapsed);
            return this.View(model);
        }

        public async Task<IActionResult> GetNextCustomers(string searchTerm)
        {
            var watch = new Stopwatch();
            watch.Start();
            var customers = (await this.customerService.GetAllCustomersDetailsAsync(CurrentPage, searchTerm))
               .Select(customer => AutoMapper.Mapper.Map<AllCustomersDetailsViewModel>(customer))
               .ToList();
            if (customers.Count() != 0)
            {
                CurrentPage++;
            }
            var time = watch.Elapsed;
            System.Console.WriteLine(time);
            return PartialView(WebConstants.AllCustomersPartial, customers);
        }


        public async Task<IActionResult> Details(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.AdminCustomersAllCustomers);
            }

            var customer = await this.customerService.GetCustomerDetailsByIdAsync(id);

            if (customer == null)
            {
                this.ShowNotification(NotificationMessages.CustomerNotExist,
                    NotificationType.Warning);
                return this.Redirect(WebConstants.AdminCustomersAllCustomers);
            }

            var result = AutoMapper.Mapper.Map<CustomerDetailsViewModel>(customer);
           

            return this.View(result);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.AdminCustomersAllCustomers);
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
                return this.Redirect(string.Format(WebConstants.AdminCustomersEdit, model.Id));
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.CustomerEditSuccessfull),
                    NotificationType.Success);

            var redirect = this.Redirect(string.Format(WebConstants.AdminCustomersDetails,model.Id));

            return redirect;
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.AdminCustomersAllCustomers);
            }
            var result = await this.customerService.SoftDeleteAsync(id);
            if (result != default(int))
            {
                this.ShowNotification(NotificationMessages.CustomerDeleteSuccessfull,
                NotificationType.Warning);
                return this.Redirect(WebConstants.AdminCustomersAllCustomers);
            }

            this.ShowNotification(NotificationMessages.InvalidOperation,
                NotificationType.Error);


            return this.Redirect(WebConstants.AdminCustomersAllCustomers);
        }

        public async Task<IActionResult> Invoice(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var invoiceFromDb = await this.invoiseService.GetInvoiceDetailsByCarIdAsync(id);

            if (invoiceFromDb == null)
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var invoiceModel = new InvoiceViewModel
            {
                FullName = invoiceFromDb.CustomerFullName,
                Email = invoiceFromDb.CustomerEmail,
                PhoneNumber = invoiceFromDb.CustomerPhoneNumber,
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
                return this.Redirect(WebConstants.HomeIndex);
            }

            var htmlData = await this.viewRenderService.RenderToStringAsync("~/Views/Invoice.cshtml", model);
            var fileContents = this.htmlToPdfConverter.Convert(this.environment.ContentRootPath, htmlData,Extensions.PDFConverter.Enums.FormatType.a4,Extensions.PDFConverter.Enums.OrientationType.Portrait);
            return this.File(fileContents, WebConstants.ApplicationPdf);
        }

        public async Task<IActionResult> CompleteTheOrder(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.RedirectToAction(nameof(AllCustomers));
            }

            var customerId = await this.carService.CompleteTheOrderByCarIdAsync(id);
            if (customerId == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Warning);

                return this.Redirect(WebConstants.AdminCustomersAllCustomers);
            }

            this.ShowNotification(NotificationMessages.CustomerOrderCompletedSuccessfully,
                NotificationType.Success);

            return this.Redirect(string.Format(WebConstants.AdminCarsCarsByCustomerId,customerId));
        }
    }
}
