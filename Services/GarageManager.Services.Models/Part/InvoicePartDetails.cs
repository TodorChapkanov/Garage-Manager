using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Part
{
    public class InvoicePartDetails : IMapFrom<Domain.Part>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
    }
}
