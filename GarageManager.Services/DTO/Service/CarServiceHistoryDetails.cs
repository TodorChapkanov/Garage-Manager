using GarageManager.Services.DTO.Part;
using GarageManager.Services.DTO.Repair;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO.Service
{
    public class CarServiceHistoryDetails
    {
        public string CarId { get; set; }

        public IEnumerable<ServiceHistoryPartDetails> Parts { get; set; }

        public IEnumerable<ServiceHistoryRepairDetails> Repairs { get; set; }
    }
}
