using GarageManager.Services.Mapping;
using System;

namespace GarageManager.Services.Models.Employee
{
    public  class EmployeeDetails : IMapFrom<Domain.GMUser>
    {
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
