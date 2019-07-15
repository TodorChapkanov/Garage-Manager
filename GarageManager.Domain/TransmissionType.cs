using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class TransmissionType
    {
        

        public string Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxTransmissionTypeNameLength)]
        public string  Type { get; set; }

    }
}
