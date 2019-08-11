using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Department;

namespace GarageManager.Web.Models.ViewModels.Department
{ 
    public class DepartmentCarDetailsViewModel : IMapFrom<DepartmentCarDetails>
    {
        public string Id { get; set; }

        public string RegistrationPlate { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }
    }
}
