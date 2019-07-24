namespace GarageManager.App.Models.BindingModels
{
    public class AddCarToServiceBindingModel
    {
        public string Id { get; set; }

        //[Required]
        //[StringLength(500, ErrorMessage = "The {0} must be between {2} and {1} symbols!")]
        public string Description { get; set; }

        public string DepartmentId { get; set; }
    }
}
