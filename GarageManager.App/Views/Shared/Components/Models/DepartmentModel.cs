using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Views.Shared.Components.Models
{
    public class DepartmentModel
    {
        public string DepartmentId { get; set; }

        [Display(Name = "Department")]
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
