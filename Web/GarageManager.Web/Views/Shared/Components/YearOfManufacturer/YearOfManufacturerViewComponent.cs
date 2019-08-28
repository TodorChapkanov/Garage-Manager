using GarageManager.Common.GlobalConstant;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Web.Views.Shared.Components.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GarageManager.Web.Views.Shared.Components.YearOfManufacturer
{
    public class YearOfManufacturerViewComponent : ViewComponent
    {

        private readonly IDateTimeProvider dateTimeProvider;

        public YearOfManufacturerViewComponent(IDateTimeProvider dateTimeProvider)
        {
            this.dateTimeProvider = dateTimeProvider;
        }

        public IViewComponentResult Invoke()
        {
            var years = new AvailableYears
            {
                Years = Enumerable
                       .Range(CarConstants.CarMinYearOfManufactorer, this.dateTimeProvider.GetDateTime().Year - CarConstants.CarMinYearOfManufactorer + 1)
                       .Select(y => new SelectListItem(y.ToString(), y.ToString()))
            };

            return this.View(WebConstants.ViewComponentDefault, years);
        }
    }
}
