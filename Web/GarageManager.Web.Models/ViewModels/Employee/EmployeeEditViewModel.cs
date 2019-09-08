using GarageManager.Common;
using GarageManager.Common.GlobalConstant;
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
        [Display(Name = DisplayNameConstants.DisplayFirstName)]
        [StringLength(
            CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage = CustomerCnstants.RegisterNameLengthErrorMessage,
            MinimumLength = CustomerCnstants.RegisterNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.DisplayLastName)]
        [StringLength(
            CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage = CustomerCnstants.RegisterNameLengthErrorMessage,
            MinimumLength = CustomerCnstants.RegisterNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(CustomerCnstants.PasswordMaxLength,
           ErrorMessage = CustomerCnstants.PasswordErrorMssage,
            MinimumLength = CustomerCnstants.PasswordMinLength)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.PhoneNumberDisplayName)]
        [RegularExpression(
            CustomerCnstants.ValidatePhonenNumberRegexPatern,
            ErrorMessage = CustomerCnstants.PhoneNumberErrorMessage)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name =DisplayNameConstants.CreatedOn)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name =DisplayNameConstants.RecruitedOn)]
        public DateTime? RecruitedOn { get; set; }

        public string DepartmentId { get; set; }

        public string TransmissionId { get; set; }

        [Display(Name = DisplayNameConstants.DisplayDepartment)]
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
