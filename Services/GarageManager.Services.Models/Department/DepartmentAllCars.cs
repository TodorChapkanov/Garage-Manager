using GarageManager.Services.Mapping;
using System.Collections.Generic;

namespace GarageManager.Services.Models.Department
{
    public class DepartmentAllCars : IMapFrom<Domain.Department>
    {
        public string  Name { get; set; }

        public ICollection<DepartmentCarDetails> Cars { get; set; }
    }
}
