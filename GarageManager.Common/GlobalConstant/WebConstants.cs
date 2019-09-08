namespace GarageManager.Common.GlobalConstant
{
    public class WebConstants
    {
        public const string HomeIndex = "/Home/Index";
        public const string Login = "/Identity/Login";

        public const string AdminCarsCreateAttributeGetPath = "/Admin/Cars/Create/{Id}";
        public const string EmployeesCarsDetails = "/Employees/Cars/Details/{0}";
        public const string AdminCarsCarsByCustomerId = "/Admin/Cars/CarsByCustomerId/{0}";
        public const string AdminCarsEdit = "/Admin/Cars/Edit/{0}";

        public const string AdminCustomersAllCustomers = "/Admin/Customers/AllCustomers";
        public const string AdminCustomersEdit = "/Admin/Customers/Edit/{0}";
        public const string AdminCustomersDetails = "/Admin/Customers/Details/{0}";

        public const string AdminAllEmnployees = "/Admin/Employees/AllEmployees";
        public const string AdminEmployeesEdit = "/Admin/Employees/Edit/{0}";
        public const string AdminEmployeesDetails = "/Admin/Employees/Details/{0}";

        public const string EmployeesDepartmentsCarsInDepartment = "/Employees/Departments/CarsInDepartment/{0}";
        public const string EmployeesCarsServiceDetails = "/Employees/Cars/ServiceDetails/{0}";
        public const string CarsByCustomerIdPartial = "_CarsByCustomerIdPartial";
        public const string AllCustomersPartial = "_AllCustomersPartial";
        public const string ApplicationPdf = "application/pdf";
        public const string ViewComponentDefault = "Default";




    }
}
