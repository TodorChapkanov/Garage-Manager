using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class Repair : IDeletableEntity
    {
        private const double MinRepairTime = 0.10;
        private const double MaxRepairTime = 24;
        private const int MaxDescriptionLength = 500;
        private const double MinPricePerHour = 10.00;
        private const double MaxPricePerHour = double.MaxValue;

        public Repair()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }
        
        [Required]
        [Range(MinRepairTime, MaxRepairTime)]
        public double Hours { get; set; }

        [Required]
        [Range(MinPricePerHour, MaxPricePerHour)]
        public decimal PricePerHour { get; set; }

        public bool IsFinished { get; set; }

        public string DepartmentId { get; set; }

        public decimal TotalCosts => this.PricePerHour * (decimal)this.Hours;

        public ICollection<ServiceRepair>  Services{ get; set; }
        public bool IsDeleted { get; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
