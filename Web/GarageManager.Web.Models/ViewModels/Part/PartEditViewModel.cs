using GarageManager.Common;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Part
{
    public class PartEditViewModel
    {
        public string Id { get; set; }

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

        [Required]
        [Range(GlobalConstants.PartQuantityMinRange,
            GlobalConstants.PartQuantityMaxRange,
            ErrorMessage = GlobalConstants.PartQuantityErrorMessage)]
        public int Quantity { get; set; }
    }
}
