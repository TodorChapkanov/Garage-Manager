using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Part;

namespace GarageManager.Web.Models.ViewModels.Part
{
    public class CarServiceHistoryPartDetailsViewModel : IMapFrom<CarServiceHistoryPartDetails>, IMapFrom<ServiceHistoryPartDetails>
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
    }
}
