using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Part
{
    public class PartEditDetils : IMapFrom<Domain.Part>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
