using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Contracts;
using GarageManager.Web.Views.Shared.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GarageManager.Web.Views.Shared.Components.Manufacturers
{
    public class ManufacturersViewComponent : ViewComponent
    {
        private readonly IManufacturerService manufacturerService;

        public ManufacturersViewComponent(IManufacturerService manufacturerService)
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

            return this.View(WebConstants.ViewComponentDefault, manufacturer);
        }
    }
}
