using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{

    public class GMUser : IdentityUser
    {
        private const int MaxFirstNameLength = 30;
        private const int MaxLastNameLength = 40;

        [Required]
        [MaxLength(MaxFirstNameLength)]
        public int FirstName { get; set; }

        [Required]
        [MaxLength(MaxLastNameLength)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.FirstName}";

        public DateTime CreatedOn { get; set; }

        public DateTime? RecruitedOn { get; set; }

        public string  DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
