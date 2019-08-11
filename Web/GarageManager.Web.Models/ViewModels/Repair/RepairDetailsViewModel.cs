using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Repair;

namespace GarageManager.Web.Models.ViewModels.Repair
{
    public class RepairDetailsViewModel : IMapFrom<RepairDetails>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }

        public decimal TotalCosts { get; set; }
    }
}
