using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Admin.ViewModels.Department
{
    public class DepartmentCarsList
    {
        public string Name { get; set; }

        public IEnumerable<DepartmentCarDetails>  Cars { get; set; }
    }
}
