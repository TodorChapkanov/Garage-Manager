using System;

namespace GarageManager.Domain
{
    public class Part : IDeletableEntity
    {
        //TODO Add Anotations
        public Part()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public decimal Price { get; set; }

        public string ServiceId { get; set; }
        public ServiceIntervention Service { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost => this.Price* (decimal) this.Quantity;

        public bool IsDeleted { get ; set ; }

        public DateTime? DeletedOn { get ; set ; }
    }
}
