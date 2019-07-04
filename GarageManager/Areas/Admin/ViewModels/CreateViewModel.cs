using Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.User.Views
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(Constants.MaxLengthCustomerName, ErrorMessage = Constants.CustomeNameLengthErrorMessage, MinimumLength = Constants.MaxLengthCustomerName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(Constants.MaxLengthCustomerName, ErrorMessage = Constants.CustomeNameLengthErrorMessage, MinimumLength = Constants.MaxLengthCustomerName)]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
