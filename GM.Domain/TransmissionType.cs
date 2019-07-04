using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class TransmissionType
    {
        private const int MaxTypeLength = 20;

        public TransmissionType()
        {
            this.Cars = new HashSet<Car>();
        }
        public string Id { get; set; }

        [Required]
        [StringLength(MaxTypeLength)]
        public string  Type { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
