using GarageManager.Web.Models.BindingModels.Part;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Part;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GarageManager.Common.Notification;
using GarageManager.Common.GlobalConstant;

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class PartsController : BaseEmployeeController
    {
        private readonly IPartService partsService;

        public PartsController(IPartService partsService)
        {
            this.partsService = partsService;
        }

        public IActionResult AddPart()
        {

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(PartCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var carId = await this.partsService
                .CreateAsync(
                model.CarId,
                model.Name,
                model.Number,
                model.Price,
                model.Quantity);

            if (!this.IsValidId(carId))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);
                return this.Redirect("/");
            }

            this.ShowNotification(string.Format(NotificationMessages.PartCreateSuccessfull, model.Number),
                   NotificationType.Success);

            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }

        public async Task<IActionResult> Edit(string id, string carId)
        {
            if (!this.IsValidId(id) || !this.IsValidId(carId))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var partFromDb = await this.partsService.GetEditDetailsByIdAsync(id);

            if (partFromDb == null)
            {
                this.ShowNotification(NotificationMessages.PartNotExist,
                    NotificationType.Warning);
                return this.Redirect($"/Employees/Cars/ServiceDetails{carId}");
            }
            var partModel = new PartEditViewModel
            {
                Id = partFromDb.Id,
                CarId = carId,
                Name = partFromDb.Name,
                Number = partFromDb.Number,
                Price = partFromDb.Price,
                Quantity = partFromDb.Quantity
            };

            return this.View(partModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var result = await this.partsService.UpdatePartByIdAsync(
                    model.Id,
                    model.Name,
                    model.Number,
                    model.Price,
                    model.Quantity);
            if (result == default(int))
            {
                this.ShowNotification(string.Format(NotificationMessages.InvalidOperation),
                    NotificationType.Error);
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }
            
            this.ShowNotification(string.Format(NotificationMessages.PartCreateSuccessfull, model.Number),
                    NotificationType.Success);
            return this.Redirect($"/Employees/Cars/ServiceDetails/{model.CarId}");
        }

        public async Task<IActionResult> Delete(string carId, string partId)
        {
            if (!this.IsValidId(carId) || !this.IsValidId(partId))
            {
                return this.Redirect("/");
            }
            var result = await this.partsService.HardDeleteAsync(partId);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);
                return this.Redirect("/");
            }

            this.ShowNotification(NotificationMessages.PartDeleteSuccessfull,
                    NotificationType.Warning);
            return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
        }
    }
}
