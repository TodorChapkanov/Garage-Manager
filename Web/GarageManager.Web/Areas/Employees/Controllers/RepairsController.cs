using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels.RepairService;
using GarageManager.Web.Models.ViewModels.Repair;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class RepairsController : BaseEmployeeController
    {
        private readonly IRepairService repairsService;

        public RepairsController(IRepairService repairsService)
        {
            this.repairsService = repairsService;
        }
        public IActionResult AddRepairService()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRepairService(RepairCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var employeeId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var carId = await this.repairsService
                .CreateAsync(
                model.CarId,
                model.Description,
                model.Hours,
                model.PricePerHour,
                employeeId);

            if (carId == default)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
               NotificationType.Warning);
                return this.Redirect(string.Format(WebConstants.EmployeesCarsServiceDetails, carId));
            }

            this.ShowNotification(NotificationMessages.RepairServiceCreateSuccessfull,
                     NotificationType.Success);
            return this.Redirect(string.Format(WebConstants.EmployeesCarsServiceDetails, carId));
        }

        public async Task<IActionResult> Edit(string id, string carId)
        {
            if (!this.IsValidId(id) || !this.IsValidId(carId))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var result = await this.repairsService.GetEditDetailsByIdAsync(id);

            if (result == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);
                return this.Redirect(string.Format(WebConstants.EmployeesCarsServiceDetails, carId));
            }
            var partModel = AutoMapper.Mapper.Map<RepairEditViewModel>(result);
            partModel.CarId = carId;
            return this.View(partModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RepairEditBindingModel model,[FromQuery] string carId)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

         var result =  await this.repairsService.UpdateRepairByIdAsync(
                model.Id,
                model.Description,
                model.Hours,
                model.PricePerHour,
                model.IsFinished);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);

                return this.Redirect(WebConstants.HomeIndex);
            }

            ShowNotification(NotificationMessages.RepairServiceEditSuccessfull,
                   NotificationType.Success);

            return this.Redirect(string.Format(WebConstants.EmployeesCarsServiceDetails, model.CarId));
        }

        public async Task<IActionResult> Delete(string carId, string repairId)
        {
            if (!this.IsValidId(carId) || !this.IsValidId(repairId))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var result = await this.repairsService.HardDeleteAsync(repairId);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);

                return this.Redirect(WebConstants.HomeIndex);
            }

            this.ShowNotification(NotificationMessages.RepairServiceDeleteSuccessfull,
                    NotificationType.Warning);

            return this.Redirect(string.Format(WebConstants.EmployeesCarsServiceDetails, carId));
        }
    }
}
