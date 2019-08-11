using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Part;
using GarageManager.Services.Models.Repair;
using System.Collections.Generic;

namespace GarageManager.Services.Models.Car
{
    public class CarServiceDetailsList : IMapFrom<Domain.Car>
    {
        public string Id { get; set; }


        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegisterPlate { get; set; }

        public string Description { get; set; }

        public string DepartmentId { get; set; }

        public IEnumerable<PartDetails> Parts { get; set; }

        public IEnumerable<RepairDetails> Repairs { get; set; }

    }
}
