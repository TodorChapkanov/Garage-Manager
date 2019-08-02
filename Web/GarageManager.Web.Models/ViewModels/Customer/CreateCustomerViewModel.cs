using GarageManager.Common.GlobalConstant;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(
            CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage = CustomerCnstants.RegisterNameLengthErrorMessage,
            MinimumLength = CustomerCnstants.RegisterNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(
            CustomerCnstants.RegisterNameMaxLength,
            ErrorMessage = CustomerCnstants.RegisterNameLengthErrorMessage, 
            MinimumLength = CustomerCnstants.RegisterNameMinLength)]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
