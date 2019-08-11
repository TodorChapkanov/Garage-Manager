using GarageManager.Domain;
using GarageManager.Services.Mapping;
using System.Collections.Generic;

namespace GarageManager.Services.Models.Department
{
    public class DepartmentCarDetails : IMapFrom<Domain.Car>
    {
        public string Id { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegistrationPlate { get; set; }

        public ICollection<ServiceIntervention> Services { get; set; }
    }
}
