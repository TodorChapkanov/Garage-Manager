using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class AvailableYears
    {
        [Required]
        [DisplayName(DisplayNameConstants.YearOfManufacturingDisplayName)]
        public int YearOfManufacturing { get; set; }

        [Required]
        public IEnumerable<SelectListItem> Years { get; set; }
    }
}
