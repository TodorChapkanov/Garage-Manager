using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Employee;

namespace GarageManager.Web.Models.ViewModels.Employee
{
    public class AllEmployeesViewModel : IMapFrom<AllEmployees>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DepartmentName { get; set; }
    }
}
