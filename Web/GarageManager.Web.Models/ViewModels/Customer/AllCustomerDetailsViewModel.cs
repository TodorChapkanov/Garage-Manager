using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Customer
{
    public class AllCustomersDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
