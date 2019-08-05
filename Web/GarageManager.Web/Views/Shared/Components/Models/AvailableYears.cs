using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class AvailableYears
    {
        [DisplayName(DisplayNameConstants.YearOfManufacturingDisplayName)]
        public int YearOfManufacturing { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
    }
}
