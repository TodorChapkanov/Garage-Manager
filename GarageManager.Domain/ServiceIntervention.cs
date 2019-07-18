using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GarageManager.Domain
{
     public class ServiceIntervention : BaseEntity
    {
        public ServiceIntervention()
        {
            this.Parts = new HashSet<ServicePart>();
            this.Repairs = new HashSet<ServiceRepair>();
        }


        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        public bool IsFinished { get; set; }

        public IEnumerable<ServicePart> Parts { get; set; }

        public IEnumerable<ServiceRepair> Repairs { get; set; }


        public decimal TotalCost => this.CalculateCosts();

        private decimal CalculateCosts()
        {
            var result = this.Parts.Sum(part => part.Part.Price) + this.Repairs.Sum(repair => (repair.Repair.PricePerHour * (decimal)repair.Repair.Hours));
            return result;
        }
    }
}
