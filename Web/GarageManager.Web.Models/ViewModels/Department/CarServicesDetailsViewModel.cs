using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Car;
using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Department
{
    public class CarServicesDetailsViewModel : IMapFrom<CarServiceDetailsList>
    {
        public string  Id { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }

        public string RegisterPlate { get; set; }

        public string Description { get; set; }

        public string DepartmentId { get; set; }

        public IEnumerable<PartDetailsViewModel> Parts { get; set; }

        public IEnumerable<RepairDetailsViewModel> Repairs { get; set; }
    }
}
