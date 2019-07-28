using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class AddCarToServiceViewModel
    {
        //TODO Constant
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} symbols!",MinimumLength =10)]
        public string  Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string DepartmentId { get; set; }
       
    }
}
