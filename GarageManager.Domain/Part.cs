using System.Collections.Generic;

namespace GarageManager.Domain
{
   public class Part
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public double Price { get; set; }

        public ICollection<ServicePart> Services { get; set; }
    }
}
