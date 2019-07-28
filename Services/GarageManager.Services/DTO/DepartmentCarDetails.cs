using GarageManager.Domain;
using System.Collections.Generic;

namespace GarageManager.Services.DTO
{
    public class DepartmentCarDetails
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string RegisterPlate { get; set; }

        public ICollection<ServiceIntervention> Services { get; set; }
    }
}
