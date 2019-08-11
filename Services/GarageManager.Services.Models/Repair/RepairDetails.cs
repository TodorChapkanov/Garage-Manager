using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Repair
{
    public class RepairDetails : IMapFrom<Domain.Repair>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }

        public decimal TotalCosts { get; set; }
    }
}
