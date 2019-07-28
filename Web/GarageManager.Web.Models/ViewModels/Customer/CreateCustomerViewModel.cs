using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(GlobalConstants.RegisterNameMaxLength, ErrorMessage = GlobalConstants.RegisterNameLengthErrorMessage, MinimumLength = GlobalConstants.RegisterNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.RegisterNameMaxLength, ErrorMessage = GlobalConstants.RegisterNameLengthErrorMessage, MinimumLength = GlobalConstants.RegisterNameMinLength)]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
