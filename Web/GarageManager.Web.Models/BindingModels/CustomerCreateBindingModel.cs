using GarageManager.Common.GlobalConstant;
using System.ComponentModel;

namespace GarageManager.Web.Models.BindingModels
{
    public class CustomerCreateBindingModel
    {
        [DisplayName(DisplayNameConstants.DisplayFirstName)]
        public string FirstName { get; set; }

        [DisplayName(DisplayNameConstants.DisplayLastName)]
        public string LastName { get; set; }

        public string Email { get; set; }

        [DisplayName(DisplayNameConstants.PhoneNumberDisplayName)]
        public string PhoneNumber { get; set; }
    }
}
