using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.App.Models.ViewModels.Customer
{
    public class CustomerDetailsViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DisplayFirstName)]
        [StringLength(
            GlobalConstants.CustomerNameMaxLength,
            ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage,
            MinimumLength = GlobalConstants.CustomerNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = GlobalConstants.DisplayLastName)]
        [StringLength(
         GlobalConstants.CustomerNameMaxLength,
         ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage,
         MinimumLength = GlobalConstants.CustomerNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [Display(Name =GlobalConstants.PhoneNumberDisplayName)]
        [StringLength(
            GlobalConstants.PhoneNumberMaxLength,
            ErrorMessage =GlobalConstants.InvalidPhoneNumber,
            MinimumLength =GlobalConstants.PhoneNumberMinLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
