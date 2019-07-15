using GarageManager.App.Areas.Admin.ViewModels.Part;
using GarageManager.App.Areas.Admin.ViewModels.Repair;
using System.Collections.Generic;

namespace GarageManager.App.Areas.Admin.ViewModels.Department
{
    public class CarServicesDetailsViewModel
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string RegisterPlate { get; set; }

        public string ServiceId { get; set; }

        public IEnumerable<PartDetailsViewModel> Parts { get; set; }

        public IEnumerable<RepairDetailsViewModel> Repairs { get; set; }
    }
}
