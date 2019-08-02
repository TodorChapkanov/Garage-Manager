using GarageManager.Common.GlobalConstant;
using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.BindingModels.Employee
{
    public class EmployeeCreateBindingModel
    {
        [Required]
        [Display(Name = DisplayNameConstants.DisplayFirstName)]
        [StringLength(CustomerCnstants.RegisterNameMaxLength, 
            ErrorMessage = AdminContants.StringLengthErrorMessage,
            MinimumLength = CustomerCnstants.RegisterNameMinLength)]
        public string FirsName { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.DisplayLastName)]
        [StringLength(CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage = AdminContants.StringLengthErrorMessage,
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
        [StringLength(CustomerCnstants.PhoneNumberMaxLength, 
            ErrorMessage = AdminContants.StringLengthErrorMessage,
            MinimumLength = CustomerCnstants.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? RecruitedOn { get; set; }

        [Required]
        public string DepartmentId { get; set; }
    }
}


