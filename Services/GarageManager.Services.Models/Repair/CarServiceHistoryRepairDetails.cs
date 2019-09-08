using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Repair
{
    public class CarServiceHistoryRepairDetails : IMapFrom<Domain.Repair>
    {
        public string Description { get; set; }

        public string EmployeeFullName { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public decimal TotalCosts { get; set; }
    }
}
