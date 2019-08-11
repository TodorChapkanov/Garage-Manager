using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class FuelTypeModel
    {
        [Required]
        [Display(Name = DisplayNameConstants.FuelTypeDisplayName)]
        public string FuelTypeId { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.FuelTypeDisplayName)]
        public IEnumerable<SelectListItem> FuelTypes { get; set; }
    }
}
