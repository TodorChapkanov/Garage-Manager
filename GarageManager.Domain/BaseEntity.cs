using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GarageManager.Domain
{
   public abstract class BaseEntity : IEntity<string>
    {

        [Key]
        [Required]
        public string Id { get; set; }
    }
}
