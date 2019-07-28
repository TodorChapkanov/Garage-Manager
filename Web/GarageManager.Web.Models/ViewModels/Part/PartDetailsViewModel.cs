namespace GarageManager.Web.Models.ViewModels.Part
{
    public class PartDetailsViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }
    }
}
