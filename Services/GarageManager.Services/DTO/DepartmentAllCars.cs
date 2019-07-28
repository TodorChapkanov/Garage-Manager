using System.Collections.Generic;

namespace GarageManager.Services.DTO
{
    public class DepartmentAllCars
    {
        public string  Name { get; set; }

        public ICollection<DepartmentCarDetails> Cars { get; set; }
    }
}
