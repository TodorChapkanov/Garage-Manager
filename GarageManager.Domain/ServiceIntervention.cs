using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GarageManager.Domain
{
     public class ServiceIntervention : BaseEntity
    {
        public ServiceIntervention()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Parts = new HashSet<Part>();
            this.Repairs = new HashSet<Repair>();
        }


        [Required]
        public string CarId { get; set; }

        public Car Car { get; set; }

        public bool IsFinished { get; set; }

        public ICollection<Part> Parts { get; set; }

        public ICollection<Repair> Repairs { get; set; }


        public decimal TotalCost => this.CalculateCosts();

        private decimal CalculateCosts()
        {
            var result = this.Parts.Sum(part => part.Price * part.Quantity) + this.Repairs.Sum(repair => (repair.PricePerHour * (decimal)repair.Hours));
            return result;
        }
    }
}
