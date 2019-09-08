using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Repair;

namespace GarageManager.Web.Models.ViewModels.Repair
{
    public class CarServiceHistoryRepairDetailsViewModel : IMapFrom<CarServiceHistoryRepairDetails>, IMapFrom<ServiceHistoryRepairDetails>
    {
        public string Description { get; set; }

        public string EmployeeFullName { get; set; }

        public double Hours { get; set; }

        public decimal PricePerHour { get; set; }

        public decimal TotalCosts { get; set; }
    }
}
