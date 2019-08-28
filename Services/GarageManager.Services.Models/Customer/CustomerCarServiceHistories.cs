using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Service;
using System.Collections.Generic;

namespace GarageManager.Services.Models.Customer
{
    public class CustomerCarServiceHistories : IMapFrom<Domain.Car>
    {
        public CustomerCarServiceHistories()
        {
            this.CarServiceHistories = new HashSet<CarServiceHistory>();
        }

        public string CustomerId { get; set; }

        public IEnumerable<CarServiceHistory> CarServiceHistories { get; set; }
    }
}
