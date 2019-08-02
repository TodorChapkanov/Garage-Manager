using GarageManager.Common.GlobalConstant;
using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class Repair : IDeletableEntity
    {
        public Repair()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

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

        public string EmployeeId { get; set; }

        public GMUser Employee { get; set; }

        public string ServiceId { get; set; }

        public ServiceIntervention Service { get; set; }

        public decimal TotalCosts => this.PricePerHour * (decimal)this.Hours;

        public bool IsFinished { get; set; }

        public bool IsDeleted { get; set ; }

        public DateTime? DeletedOn { get ; set ; }
    }
}
