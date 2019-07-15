using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class ServicePart
    {
        [Required]
        public string ServiceId { get; set; }
        public ServiceInterventions Service { get; set; }

        [Required]
        public string PartId { get; set; }
        public Part Part { get; set; }
    }
}
