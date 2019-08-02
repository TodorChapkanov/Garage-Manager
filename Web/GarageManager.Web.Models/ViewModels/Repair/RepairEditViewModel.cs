using GarageManager.Common.GlobalConstant;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Repair
{
    public class RepairEditViewModel
    {
        public string Id { get; set; }

        public string CarId { get; set; }

        [Required]
        [StringLength(
            RepairConstants.RepairDescriptionMaxLength,
            ErrorMessage = AdminContants.StringLengthErrorMessage,
            MinimumLength = RepairConstants.RepairDescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [Range(RepairConstants.MinRepairTime,
            RepairConstants.MaxRepairTime,
            ErrorMessage = RepairConstants.RepairTimeErrorMessage)]
        public double Hours { get; set; }

        [Required]
        [Range(RepairConstants.RepairMinPricePerHour,
            RepairConstants.RepairMaxPricePerHour,
            ErrorMessage = RepairConstants.RepairPricePerHourErrorMessage)]
        public decimal PricePerHour { get; set; }

        public string EmployeeName { get; set; }

        public bool IsFinished { get; set; }
    }
}
