using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Part;
using GarageManager.Services.Models.Repair;
using System.Collections.Generic;

namespace GarageManager.Services.Models.Service
{
    public class CompletedCarServiceDetails : IMapFrom<Domain.Car>
    {
        public CompletedCarServiceDetails()
        {
            this.ServicesParts = new HashSet<CarServiceHistoryPartDetails>();
            this.ServicesRepairs = new HashSet<CarServiceHistoryRepairDetails>();
        }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegistrationPlate { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }

        public IEnumerable<CarServiceHistoryPartDetails> ServicesParts { get; set; }

        public IEnumerable<CarServiceHistoryRepairDetails> ServicesRepairs { get; set; }
    }
}
