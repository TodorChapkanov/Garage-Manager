using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Repair;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Repair
{
    public class RepairEditViewModel : IMapFrom<RepairEditDetails>
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

        [Display(Name = DisplayNameConstants.DisplayEmployeeFullName)]
        public string EmployeeFullName { get; set; }

        public bool IsFinished { get; set; }
    }
}
