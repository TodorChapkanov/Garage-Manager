using GarageManager.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{

    public class GMUser :  IdentityUser, IEntity<string>, IDeletableEntity
    {
        public GMUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(GlobalConstants.RegisterNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.RegisterNameMaxLength)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.FirstName}";

        public DateTime CreatedOn { get; set; }

        public DateTime? RecruitedOn { get; set; }

        public string  DepartmentId { get; set; }

        public Department Department { get; set; }
        public bool IsDeleted { get; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
