using System.Collections.Generic;

namespace GarageManager.App.Models.ViewModels.Department
{ 
    public class DepartmentCarsList
    {
        public string Name { get; set; }

        public IEnumerable<DepartmentCarDetails>  Cars { get; set; }
    }
}
