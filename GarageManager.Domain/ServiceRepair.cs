using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class ServiceRepair : IDeletableEntity
    {
        [Required]
        public string ServiceId { get; set; }
        public ServiceIntervention Service { get; set; }

        [Required]
        public string RepairId { get; set; }
        public Repair Repair { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
