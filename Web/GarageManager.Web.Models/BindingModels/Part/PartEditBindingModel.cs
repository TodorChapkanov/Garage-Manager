namespace GarageManager.Web.Models.BindingModels.Part
{
    public class PartEditBindingModel
    {
        public string Id { get; set; }

        public string CarId { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
