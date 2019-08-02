using GarageManager.Common;
using GarageManager.Common.GlobalConstant;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class CustomerDetailsViewModel
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
        [Display(Name = DisplayNameConstants.PhoneNumberDisplayName)]
        [StringLength(
            CustomerCnstants.PhoneNumberMaxLength,
            ErrorMessage = CustomerCnstants.InvalidPhoneNumber,
            MinimumLength = CustomerCnstants.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
