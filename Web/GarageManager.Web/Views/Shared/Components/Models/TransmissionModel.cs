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
        public string TransmissionId { get; set; }

        [Display(Name ="Transmission")]
        public IEnumerable<SelectListItem>  Transmissions { get; set; }
    }
}
