using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.ServiceIntervention
{
    public class CarServiceHistoryDetailsViewModel
    {
        public string  CarId { get; set; }

        public IEnumerable<CarServiceHistoryPartDetailsViewModel> Parts { get; set; }

        public IEnumerable<CarServiceHistoryRepairDetailsViewModel> Repairs { get; set; }
    }
}
