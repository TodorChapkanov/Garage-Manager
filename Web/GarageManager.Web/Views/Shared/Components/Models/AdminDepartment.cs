using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Department;

namespace GarageManager.Web.Views.Shared.Components.Models
{
    public class AdminDepartment : IMapFrom<DepartmentAll>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
