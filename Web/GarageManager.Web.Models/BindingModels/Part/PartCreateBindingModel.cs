using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.BindingModels.Part
{
    public class PartCreateBindingModel
    {
        [BindProperty(Name = "id")]
        public string CarId { get; set; }

        [Required]
        [StringLength(
            PartConstants.PartNameMaxLength,
            ErrorMessage = AdminContants.StringLengthErrorMessage,
            MinimumLength = PartConstants.PartNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            PartConstants.PartNumberMaxLength,
            ErrorMessage = AdminContants.StringLengthErrorMessage,
            MinimumLength = PartConstants.PartNumberMinLength)]
        public string Number { get; set; }

        [Required]
        [Range(
            PartConstants.PartPriceMinValue,
            PartConstants.PartPriceMaxValue,
            ErrorMessage = PartConstants.PartPriceErrorMessage)]
        public decimal Price { get; set; }

        [Required]
        [Range(PartConstants.PartQuantityMinRange,
            PartConstants.PartQuantityMaxRange,
            ErrorMessage = PartConstants.PartQuantityErrorMessage)]
        public int Quantity { get; set; }
    }
}
