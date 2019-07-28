using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GarageManager.Domain
{
   public abstract class BaseEntity : IEntity<string>, IDeletableEntity
    {

        [Key]
        [Required]
        public string Id { get; set; }

        public bool IsDeleted { get ; set ; }

        public DateTime? DeletedOn { get ; set; }
    }
}
