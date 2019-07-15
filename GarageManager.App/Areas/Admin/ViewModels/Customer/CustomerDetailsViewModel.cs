using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.Admin.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
