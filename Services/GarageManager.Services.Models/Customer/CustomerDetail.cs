using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Customer
{
    public class CustomerDetail : IMapFrom<Domain.Customer>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
