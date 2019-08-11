using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Department
{
    public class DepartmentAll :IMapFrom<Domain.Department>
    {
        public string  Id { get; set; }

        public string Name { get; set; }
    }
}
