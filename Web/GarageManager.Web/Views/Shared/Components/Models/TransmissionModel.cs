using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class TransmissionModel
    {
        [Required(ErrorMessage = "Transmission")]
        public string TransmissionId { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.DisplayTransmissionType)]
        public IEnumerable<SelectListItem>  Transmissions { get; set; }
    }
}
