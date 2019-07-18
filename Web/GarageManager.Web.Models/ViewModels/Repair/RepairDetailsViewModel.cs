namespace GarageManager.App.Models.ViewModels.Repair
{
    public class RepairDetailsViewModel
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }

        public decimal TotalCost { get; set; }
    }
}
