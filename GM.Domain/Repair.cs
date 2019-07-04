using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class Repair
    {
        private const double MinRepairTime = 0.10;
        private const double MaxRepairTime = 24;
        private const int MaxDescriptionLength = 500;
        private const double MinPricePerHour = 10.00;
        private const double MaxPricePerHour = double.MaxValue;

        public string Id { get; set; }

        [Required]
        [StringLength(MaxDescriptionLength)]
        public string Description { get; set; }
        
        [Required]
        [Range(MinRepairTime, MaxRepairTime)]
        public double Hours { get; set; }

        [Required]
        [Range(MinPricePerHour, MaxPricePerHour)]
        public double PricePerHour { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        [Required]
        public string MechanicId { get; set; }

        public GMUser Mechanic { get; set; }

        public ICollection<ServiceRepair>  Services{ get; set; }
    }
}
