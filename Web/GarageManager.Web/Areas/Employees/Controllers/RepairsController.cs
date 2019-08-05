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
        private readonly IRepairsService repairsService;

        public RepairsController(IRepairsService repairsService)
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
            //TODO Add View Component for Employees in Department
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            var employeeId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var carId = await this.repairsService
                .CreateRepairService(
                model.CarId,
                model.Description,
                model.Hours,
                model.PricePerHour,
                employeeId);

            if (carId == default(string))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
               NotificationType.Warning);
                return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
            }

            this.ShowNotification(NotificationMessages.RepairServiceCreateSuccessfull,
                     NotificationType.Success);
            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }

        public async Task<IActionResult> Edit(string id, string carId)
        {
            if (!this.IsValidId(id) || !this.IsValidId(carId))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var partFromDb = await this.repairsService.GetEditDetailsByIdAsync(id);

            if (partFromDb == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);
                return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
            }
            var partModel = new RepairEditViewModel
            {
                Id = partFromDb.Id,
                CarId = carId,
                Description = partFromDb.Description,
                PricePerHour = partFromDb.PricePerHour,
                Hours = partFromDb.Hours,
                EmployeeName = partFromDb.EmployeeName,
                IsFinished = partFromDb.IsFinished
            };//TODO Add VC For employees in rapir edit view

            return this.View(partModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RepairEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Home/Index");
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

                return this.Redirect("/");
            }

            ShowNotification(NotificationMessages.RepairServiceEditSuccessfull,
                   NotificationType.Success);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{model.CarId}");
        }

        public async Task<IActionResult> Delete(string carId, string repairId)
        {
            if (!this.IsValidId(carId) || !this.IsValidId(repairId))
            {
                return this.Redirect("/");
            }

            var result = await this.repairsService.HardDeleteAsync(repairId);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);

                return this.Redirect("/");
            }

            this.ShowNotification(NotificationMessages.RepairServiceDeleteSuccessfull,
                    NotificationType.Warning);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }
    }
}
