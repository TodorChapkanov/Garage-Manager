using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Customer
{
    public class CustomerEditDetails : IMapFrom<Domain.Customer>
    {
        public string Id { get; set; }
        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
