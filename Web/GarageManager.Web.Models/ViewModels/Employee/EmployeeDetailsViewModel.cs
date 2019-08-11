using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Employee;
using System;

namespace GarageManager.Web.Models.ViewModels.Employee
{
    public class EmployeeDetailsViewModel : IMapFrom<EmployeeDetails>
    {
        public EmployeeDetailsViewModel()
        {
        }

        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? RecruitedOn { get; set; }

        public string DepartmentName { get; set; }
    }
}
