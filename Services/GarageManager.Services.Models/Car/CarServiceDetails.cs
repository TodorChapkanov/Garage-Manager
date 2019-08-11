using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Car
{
    public class CarServiceDetails : IMapFrom<Domain.Car>
    {

        public string Description { get; set; }

        public string DepartmentId { get; set; }
    }
}
