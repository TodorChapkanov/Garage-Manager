using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class DepartmentModel
    {
        [Required]
        public string DepartmentId { get; set; }

        [Display(Name = DisplayNameConstants.DisplayDepartment)]
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
