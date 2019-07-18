using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class ServicePart : IDeletableEntity
    {
        [Required]
        public string ServiceId { get; set; }
        public ServiceIntervention Service { get; set; }

        [Required]
        public string PartId { get; set; }
        public Part Part { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
