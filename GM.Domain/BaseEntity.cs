using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GM.Domain
{
   public class BaseEntity
    {

        [Key]
        [Required]
        public string Id { get; set; }
    }
}
