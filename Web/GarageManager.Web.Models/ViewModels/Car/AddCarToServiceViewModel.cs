using GarageManager.Common.GlobalConstant;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class AddCarToServiceViewModel
    {
        [Required]
        [StringLength(CarConstants.CarDescriptionMaxLength,
            ErrorMessage = CarConstants.CarDescriptionErrorMessage,
            MinimumLength = CarConstants.CarDescriptionMinLength)]
        public string  Description { get; set; }

        [Required]
        public string DepartmentId { get; set; }
       
    }
}
