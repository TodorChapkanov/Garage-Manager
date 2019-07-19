using GarageManager.Common;
using System;
using System.Collections.Generic;
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

        public string ServiceId { get; set; }

        public ServiceIntervention Service { get; set; }

        public decimal TotalCosts => this.PricePerHour * (decimal)this.Hours;

        public bool IsDeleted { get; set ; }

        public DateTime? DeletedOn { get ; set ; }
    }
}
