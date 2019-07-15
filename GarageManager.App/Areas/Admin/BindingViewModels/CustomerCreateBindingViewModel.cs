using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.Admin.BindingViewModels
{
    public class CustomerCreateBindingViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
