using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Repair
{
    public class RepairEditViewModel
    {
        public string Id { get; set; }

        public string CarId { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.RepairDescriptionMaxLength,
            ErrorMessage = GlobalConstants.StringLengthErrorMessage,
            MinimumLength = GlobalConstants.RepairDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Range(GlobalConstants.MinRepairTime,
            GlobalConstants.MaxRepairTime,
            ErrorMessage = GlobalConstants.RepairTimeErrorMessage)]
        public double Hours { get; set; }

        [Required]
        [Range(GlobalConstants.RepairMinPricePerHour,
            GlobalConstants.RepairMaxPricePerHour,
            ErrorMessage = GlobalConstants.RepairPricePerHourErrorMessage)]
        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }
    }
}
