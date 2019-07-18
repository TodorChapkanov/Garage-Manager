using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GarageManager.Web.Models.BindingModels.Employee
{
    public class EmployeeCreateBindingModel
    {
        [Required]
        public string FirsName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime? RecruitedOn { get; set; }

        [Required]
        public string DepartmentId { get; set; }
    }
}


