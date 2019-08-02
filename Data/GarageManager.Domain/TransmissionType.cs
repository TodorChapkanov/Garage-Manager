using GarageManager.Common.GlobalConstant;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class TransmissionType : BaseEntity
    {
        [Required]
        [StringLength(
            TransmissionConstants.MaxTransmissionTypeNameLength,
            ErrorMessage =AdminContants.StringLengthErrorMessage,
            MinimumLength = TransmissionConstants.MinTransmissionTypeNameLength
            )]
        public string  Type { get; set; }

    }
}
