using GarageManager.Common;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.App.Models.BindingModels.Part
{
    public class PartCreateBindingModel
    {
        [BindProperty(Name = "id")]
        public string CarId { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.PartNameMaxLength,
            ErrorMessage = GlobalConstants.StringLengthErrorMessage, 
            MinimumLength = GlobalConstants.PartNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.PartNumberMaxLength,
            ErrorMessage = GlobalConstants.StringLengthErrorMessage,
            MinimumLength = GlobalConstants.PartNumberMinLength)]
        public string Number { get; set; }

        [Required]
        [Range(
            GlobalConstants.PartPriceMinValue,
            GlobalConstants.PartPriceMaxValue,
            ErrorMessage = GlobalConstants.PartPriceErrorMessage)]
        public decimal Price { get; set; }
    }
}
