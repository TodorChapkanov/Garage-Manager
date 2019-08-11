using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Part
{
    public class ServiceHistoryPartDetails : IMapFrom<Domain.Part>
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
    }
}
