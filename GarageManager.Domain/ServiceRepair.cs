using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class ServiceRepair
    {
        [Required]
        public string ServiceId { get; set; }
        public ServiceInterventions Service { get; set; }

        [Required]
        public string RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}
