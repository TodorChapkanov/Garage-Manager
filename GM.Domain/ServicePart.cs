using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class ServicePart
    {
        [Required]
        public string ServiceId { get; set; }
        public Service Service { get; set; }

        [Required]
        public string PartId { get; set; }
        public Part Part { get; set; }
    }
}
