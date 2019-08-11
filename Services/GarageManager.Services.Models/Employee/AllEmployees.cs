using GarageManager.Domain;
using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Employee
{
    public class AllEmployees :IMapFrom<GMUser>
    {
        public string  Id { get; set; }

        public string  FullName { get; set; }

        public string  Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DepartmentName { get; set; }
    }
}
