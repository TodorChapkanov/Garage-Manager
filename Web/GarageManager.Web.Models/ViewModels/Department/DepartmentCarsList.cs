using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Department
{ 
    public class DepartmentCarsList
    {
        public string Name { get; set; }

        public IEnumerable<DepartmentCarDetails>  Cars { get; set; }
    }
}
