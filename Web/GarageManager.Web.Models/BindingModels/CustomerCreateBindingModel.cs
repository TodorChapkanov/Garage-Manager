using GarageManager.Common.GlobalConstant;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.BindingModels
{
    public class CustomerCreateBindingModel
    {
        [Required]
        [DisplayName(DisplayNameConstants.DisplayFirstName)]
        [StringLength(
            CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage =CustomerCnstants.RegisterNameLengthErrorMessage,
            MinimumLength =CustomerCnstants.RegisterNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName(DisplayNameConstants.DisplayLastName)]
        [StringLength(
            CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage =CustomerCnstants.RegisterNameLengthErrorMessage,
            MinimumLength =CustomerCnstants.RegisterNameMinLength)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DisplayName(DisplayNameConstants.PhoneNumberDisplayName)]
        [RegularExpression(
            CustomerCnstants.ValidatePhonenNumberRegexPatern,
            ErrorMessage =CustomerCnstants.PhoneNumberErrorMessage)]
        public string PhoneNumber { get; set; }
    }
}
