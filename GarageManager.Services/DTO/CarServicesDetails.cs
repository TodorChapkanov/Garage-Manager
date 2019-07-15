using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO
{
    public class CarServicesDetails
    {
        public string Make { get; set; }

        public string Model { get; set; }

        public string RegisterPlate { get; set; }

        public string ServiceId { get; set; }

        public IEnumerable<PartDetails> Parts { get; set; }

        public IEnumerable<RepairDetails> Repairs { get; set; }

    }
}
