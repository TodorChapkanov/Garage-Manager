using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
     public class ServiceInterventions
    {
        public ServiceInterventions()
        {
            this.Parts = new HashSet<ServicePart>();
            this.Repairs = new HashSet<ServiceRepair>();
        }

        public string Id { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        public bool IsFinished { get; set; }

        public IEnumerable<ServicePart> Parts { get; set; }

        public IEnumerable<ServiceRepair> Repairs { get; set; }

        
        public decimal TotalCost { get; set; }
    }
}
