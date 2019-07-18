using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO
{
    public class CarServicesDetails
    {
        public string Id { get; set; }


        public string Make { get; set; }

        public string Model { get; set; }

        public string RegisterPlate { get; set; }

        public string Description { get; set; }

        public IEnumerable<PartDetails> Parts { get; set; }

        public IEnumerable<RepairDetails> Repairs { get; set; }

    }
}
