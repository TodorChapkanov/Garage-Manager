using GarageManager.Common.GlobalConstant;
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
        [Required ]
        [Display(Name = DisplayNameConstants.ManufacturersDisplayName)]
        public string ManufacturerId { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.ManufacturersDisplayName)]
        public IEnumerable<SelectListItem> AllManufacturers { get; set; }
    }
}
