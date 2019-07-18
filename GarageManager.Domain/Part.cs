using System;
using System.Collections.Generic;

namespace GarageManager.Domain
{
   public class Part : IDeletableEntity
    {
        public Part()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public decimal Price { get; set; }

        public string DepartmentId { get; set; }

        public ICollection<ServicePart> Services { get; set; }
        public bool IsDeleted { get ; set ; }
        public DateTime? DeletedOn { get ; set ; }
    }
}
