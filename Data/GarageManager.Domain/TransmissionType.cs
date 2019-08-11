using GarageManager.Common.GlobalConstant;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class TransmissionType : BaseEntity
    {
        [Required]
        [MaxLength( TransmissionConstants.MaxTransmissionTypeNameLength)]
        public string  Name { get; set; }

    }
}
