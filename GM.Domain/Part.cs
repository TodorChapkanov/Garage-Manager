using System.Collections.Generic;

namespace GM.Domain
{
   public class Part
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public double Price { get; set; }

        public string CarId { get; set; }

        public Car Car { get; set; }

        public ICollection<ServicePart> Services { get; set; }
    }
}
