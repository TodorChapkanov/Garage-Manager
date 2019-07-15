using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.User.Views
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(GlobalConstants.MaxLengthCustomerName, ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage, MinimumLength = GlobalConstants.MinLengthCutomerName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLengthCustomerName, ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage, MinimumLength = GlobalConstants.MinLengthCutomerName)]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
