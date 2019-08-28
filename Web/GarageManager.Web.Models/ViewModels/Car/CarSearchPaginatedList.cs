using GarageManager.Web.Models.ViewModels.Page;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CarSearchPaginatedList
    {
        public string  SearachTerm { get; set; }

        public string CustomerId { get; set; }

        public PaginatedList<CustomerCarDetailsViewModel> Cars { get; set; }
    }
}
