using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Identity;
using System;
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
        [MaxLength(CustomerCnstants.RegisterNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(CustomerCnstants.RegisterNameMaxLength)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        public DateTime CreatedOn { get; set; }

        public DateTime? RecruitedOn { get; set; }

        public string  DepartmentId { get; set; }

        public Department Department { get; set; }
        public bool IsDeleted { get; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
