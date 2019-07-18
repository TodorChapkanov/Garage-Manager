using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.App.Views.Shared.Components.Models
{
    public class FuelTypeModel
    {
        public string FuelTypeId { get; set; }

        [Display(Name ="Fuel Type")]
        public IEnumerable<SelectListItem> FuelTypes { get; set; }
    }
}
