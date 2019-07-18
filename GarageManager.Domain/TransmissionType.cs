using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class TransmissionType : BaseEntity
    {
        [Required]
        [StringLength(GlobalConstants.MaxTransmissionTypeNameLength)]
        public string  Type { get; set; }

    }
}
