using GarageManager.Common.GlobalConstant;
using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class Part : IDeletableEntity
    {
     
        public Part()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(PartConstants.PartNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PartConstants.PartNumberMaxLength)]
        public string Number { get; set; }

        [Required]
        [Range(PartConstants.PartPriceMinValue, PartConstants.PartPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(PartConstants.PartQuantityMinRange, PartConstants.PartQuantityMaxRange)]
        public int Quantity { get; set; }
        [Required]
        public string ServiceId { get; set; }
        public ServiceIntervention Service { get; set; }

        public decimal TotalCost => this.Price* (decimal) this.Quantity;

        public bool IsDeleted { get ; set ; }

        public DateTime? DeletedOn { get ; set ; }
    }
}
