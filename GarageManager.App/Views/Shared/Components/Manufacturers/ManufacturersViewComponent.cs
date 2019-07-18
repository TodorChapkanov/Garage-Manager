using GarageManager.App.Views.Shared.Components.Models;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GarageManager.App.Views.Shared.Components.Manufacturers
{
    public class ManufacturersViewComponent : ViewComponent
    {
        private readonly IManufacturerServices manufacturerService;

        public ManufacturersViewComponent(IManufacturerServices manufacturerService)
        {
            this.manufacturerService = manufacturerService;
        }

        public  IViewComponentResult Invoke()
        {
            var manufacturer = new ManufacturerModel
            {
                AllManufacturers = this.manufacturerService
               .GetAllAsync()
               .Result
               .OrderBy(m => m.Name)
               .Select(m => new SelectListItem
               {
                   Text = m.Name,
                   Value = m.Id
               }).ToList()
            };

            return this.View("Default", manufacturer);
        }
    }
}
