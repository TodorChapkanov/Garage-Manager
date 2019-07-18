﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.App.Models.ViewModels.Car
{
    public class AddToServiceViewModel
    {
        public AddToServiceViewModel()
        {
            this.Departments = new List<SelectListItem>();
        }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} symbols!",MinimumLength =20)]
        public string  Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string DepartmentId { get; set; }
       
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}