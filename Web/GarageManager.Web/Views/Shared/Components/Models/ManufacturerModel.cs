using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class ManufacturerModel
    {
        public string ManufacturerId { get; set; }

        [Display(Name ="Manufacturer")]
        public IEnumerable<SelectListItem> AllManufacturers { get; set; }
    }
}
