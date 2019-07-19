using GarageManager.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Employee
{
    public class EmployeeEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DisplayFirstName)]
        [StringLength(GlobalConstants.RegisterNameMaxLength, ErrorMessage = GlobalConstants.RegisterNameLengthErrorMessage, MinimumLength = GlobalConstants.RegisterNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DisplayLastName)]
        [StringLength(GlobalConstants.RegisterNameMaxLength, ErrorMessage = GlobalConstants.RegisterNameLengthErrorMessage, MinimumLength = GlobalConstants.RegisterNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(GlobalConstants.PasswordMaxLength,
           ErrorMessage = GlobalConstants.PasswordErrorMssage,
            MinimumLength = GlobalConstants.PasswordMinLength)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = GlobalConstants.PhoneNumberDisplayName)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RecruitedOn { get; set; }

        public string DepartmentId { get; set; }

        public string TransmissionId { get; set; }

        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
