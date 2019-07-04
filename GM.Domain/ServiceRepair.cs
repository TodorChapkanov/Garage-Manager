using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class ServiceRepair
    {
        [Required]
        public string ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public string RepairId { get; set; }
        public Repair Repair { get; set; }
    }
}
