namespace GarageManager.Services.DTO.Repair
{
    public class RepairEditDetails
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal PricePerHour { get; set; }

        public double  Hours { get; set; }

        public bool IsFinished { get; set; }
    }
}
