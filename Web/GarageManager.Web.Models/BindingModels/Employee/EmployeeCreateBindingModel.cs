using GarageManager.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GarageManager.Web.Models.BindingModels.Employee
{
    public class EmployeeCreateBindingModel
    {
        [Required]
        [Display(Name = GlobalConstants.DisplayFirstName)]
        [StringLength(GlobalConstants.RegisterNameMaxLength, 
            ErrorMessage = GlobalConstants.StringLengthErrorMessage,
            MinimumLength = GlobalConstants.RegisterNameMinLength)]
        public string FirsName { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DisplayLastName)]
        [StringLength(GlobalConstants.RegisterNameMaxLength,
            ErrorMessage = GlobalConstants.StringLengthErrorMessage,
            MinimumLength = GlobalConstants.RegisterNameMinLength)]
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
        [StringLength(GlobalConstants.PhoneNumberMaxLength, 
            ErrorMessage = GlobalConstants.StringLengthErrorMessage,
            MinimumLength = GlobalConstants.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RecruitedOn { get; set; }

        [Required]
        public string DepartmentId { get; set; }
    }
}


