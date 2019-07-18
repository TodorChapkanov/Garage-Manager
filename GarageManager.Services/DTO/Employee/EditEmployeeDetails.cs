using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO.Employee
{
    public class EditEmployeeDetails
    {
        public string FirstName { get; set; }

        public string  LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? RecruitedOn { get; set; }

        public string DepartmentId { get; set; }
    }
}
