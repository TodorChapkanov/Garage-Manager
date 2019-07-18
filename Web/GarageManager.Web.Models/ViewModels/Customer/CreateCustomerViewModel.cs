using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.App.Models.ViewModels.Customer
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(GlobalConstants.CustomerNameMaxLength, ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage, MinimumLength = GlobalConstants.CustomerNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.CustomerNameMaxLength, ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage, MinimumLength = GlobalConstants.CustomerNameMinLength)]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
