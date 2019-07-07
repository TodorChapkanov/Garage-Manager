using Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.Admin.BindingViewModels
{
    public class CustomerCreate
    {
        [Required]
        [Display(Name ="First Name")]
        [StringLength(GlobalConstants.MaxLengthCustomerName, ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage, MinimumLength = GlobalConstants.MinLengthCutomerName)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        [StringLength(GlobalConstants.MaxLengthCustomerName, ErrorMessage = GlobalConstants.CustomeNameLengthErrorMessage, MinimumLength = GlobalConstants.MinLengthCutomerName)]
        public string LastName { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(GlobalConstants.PhoneNumberMaxLength,ErrorMessage =GlobalConstants.InvalidPhoneNumber, MinimumLength = GlobalConstants.PhoneNumberMinLength)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
