using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Service;
using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.ServiceIntervention
{
    public class CarServiceHistoryDetailsViewModel : IMapFrom<CarServiceHistoryDetails>
    {
        public string  CarId { get; set; }

        public IEnumerable<CarServiceHistoryPartDetailsViewModel> Parts { get; set; }

        public IEnumerable<CarServiceHistoryRepairDetailsViewModel> Repairs { get; set; }
    }
}
