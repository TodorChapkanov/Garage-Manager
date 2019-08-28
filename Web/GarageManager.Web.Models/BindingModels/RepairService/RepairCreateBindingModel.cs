using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.BindingModels.RepairService
{
    public class RepairCreateBindingModel
    {

        [BindProperty(Name = "id")]
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
        [Display(Name =DisplayNameConstants.RepairServicePricePerHourDisplayName)]
        [Range(RepairConstants.RepairMinPricePerHour,
            RepairConstants.RepairMaxPricePerHour,
            ErrorMessage = RepairConstants.RepairPricePerHourErrorMessage)]
        public decimal PricePerHour { get; set; }


    }
}
