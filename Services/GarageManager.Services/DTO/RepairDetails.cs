namespace GarageManager.Services.DTO
{
    public class RepairDetails
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }

        public decimal TotalCosts { get; set; }
    }
}
