using GarageManager.Domain;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Part;
using GarageManager.Services.Models.Repair;
using System.Collections.Generic;

namespace GarageManager.Services.Models.Service
{
    public class CarServiceHistoryDetails : IMapFrom<ServiceIntervention>
    {
        public string CarId { get; set; }

        public IEnumerable<ServiceHistoryPartDetails> Parts { get; set; }

        public IEnumerable<ServiceHistoryRepairDetails> Repairs { get; set; }
    }
}
