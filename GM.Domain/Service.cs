using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
     public class Service
    {
        public string Id { get; set; }

        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        public bool IsFinished { get; set; }

        public ICollection<ServicePart> Parts { get; set; }

        public ICollection<ServiceRepair> Repairs { get; set; }

        
        public decimal TotalCost { get; set; }
    }
}
