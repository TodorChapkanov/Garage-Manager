namespace GarageManager.Common
{
    public class GlobalConstants
    {
        // Customer Form 
        public const int MinLengthCutomerName = 3;
        public const int MaxLengthCustomerName = 20;
        public const string CustomeNameLengthErrorMessage = "Name should be between {2} and {1} symbols!";
        public const int PasswordMinLength = 4;
        public const int PasswordMaxLength = 20;
        public const string PasswordErrorMssage = "Password should be between {2} and{1} symbold";
        public const string ConfirmPasswordError = "Confirm Password and Password are not equal!";
        public const string InvalidPhoneNumber = "The Phone Number is not valid";
        public const int PhoneNumberMinLength = 8;
        public const int PhoneNumberMaxLength = 14;

        //Car 
        public  const int CarVinNumberMaxLength = 17;
        public  const int CarMinKilometers = 0;
        public  const int CarMaxKilometers = 1000000;
        public  const int CarMinYearOfManufactore = 1886;
        public  const int CarMaxEngineHorsePower = 5000;
        public  const int CarMinEngineHorsePower = 15;
        public  const int CarMaxEngineModelLength = 20;
        public const int CarRegistrationPlateMaxLenth = 10;
        public const int CarRegistrationPlateMinLenth = 4;
        public const string CarRegistrationPlateErrorMassege = "Invalid Registration Plate";
        public const int CarDescriptionMaxLength = 500;

        //Transmission Type
        public const int MaxTransmissionTypeNameLength = 20;

        //Administrator Roles
        public const string AdministratorRoleName = "Admin";
        public const string ТinsmithDepartmentManagerRoleName = "ТinsmithDepartmentManager";
        public const string PaintingDepartmentManagerRoleName = "PaintingDepartmentManager";
        public const string MechanikDepartmentManagerRoleName = "MechanikDepartmentManager";
        public const string WarehouseDepartmentManagerRoleName = "WarehouseDepartmentManager";

        public const string DefaultLogoutUrl = "/Home/Index";

        //Display Names
        public const string CustomerFirsDisplayName = "Firs Name";
        public const string CustomerLastDisplayName = "Last Name";
        public const string CarYearOfManufacturingDisplayName = "Year of Manugacturing";
        public const string CarEngineModelDisplayName = "Engine Model";
        public const string CarEngineHorsePowerDisplayName = "Engine Horse Power";
        public const string CarFuelTypeDisplayName = "Fuel Type";
        public const string CarModelDisplayName = "Model";
        public const string CarManufacturersDisplayName = "Make";
        public const string CarRegistrationPlateDisplayName = "Registration Plate";
    }
}
