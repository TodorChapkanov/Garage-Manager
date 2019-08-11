using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Repair
{
    public class RepairEditDetails : IMapFrom<Domain.Repair>
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal PricePerHour { get; set; }

        public double  Hours { get; set; }

        public string EmployeeFullName { get; set; }

        public bool IsFinished { get; set; }
    }
}
