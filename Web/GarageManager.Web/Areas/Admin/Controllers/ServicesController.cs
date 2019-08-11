using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using GarageManager.Web.Models.ViewModels.ServiceIntervention;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Admin.Controllers
{
    public class ServicesController : BaseAdminController
    {
        private readonly IInterventionService interventionService;

        public ServicesController(IInterventionService interventionService)
        {
            this.interventionService = interventionService;
        }

        public async Task<IActionResult> ServiceHistoryByCarId(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }

            try
            {
                var model = (await this.interventionService.GetCarServicesHistoryByCarIdAsync(id))
               .Select(service => AutoMapper.Mapper.Map<CarServiceHistoryViewModel>(service))
               .OrderByDescending(service => service.FinishedOn);

                return this.View(model);
            }
            catch 
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);
                return this.Redirect(RedirectUrl_s.AdminCustomersAllCustomers);
            }
        }

        public async Task<IActionResult> ServiceDetails(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }
            var serviceDetails = await this.interventionService.GetServiceHistoryDetailsByIdAsync(id);
            var model = AutoMapper.Mapper.Map<CarServiceHistoryDetailsViewModel>(serviceDetails);
         
            return this.View(model);
        }
    }
}
