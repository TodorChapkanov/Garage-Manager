using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Department;
using System.Collections.Generic;

namespace GarageManager.Web.Models.ViewModels.Department
{ 
    public class DepartmentCarsList : IMapFrom<DepartmentAllCars>
    {
        public string Name { get; set; }

        public IEnumerable<DepartmentCarDetailsViewModel>  Cars { get; set; }
    }
}
