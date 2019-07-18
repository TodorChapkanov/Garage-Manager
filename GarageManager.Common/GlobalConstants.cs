namespace GarageManager.Common
{
    public class GlobalConstants
    {
        public const string StringLengthErrorMessage = "{0} should be between {2} and {1} symbols!";
        // Customer Form 
        public const int CustomerNameMinLength = 3;
        public const int CustomerNameMaxLength = 20;
        public const string CustomeNameLengthErrorMessage = "{0} should be between {2} and {1} symbols!";
        public const int PasswordMinLength = 4;
        public const int PasswordMaxLength = 20;
        public const string PasswordErrorMssage = "{0} should be between {2} and{1} symbold!";
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
        public const string EmployeeRoleName = "Employee";

        public const string DefaultLogoutUrl = "/Home/Index";

        //Display Names
        public const string DisplayFirstName = "Firs Name";
        public const string DisplayLastName = "Last Name";
        public const string YearOfManufacturingDisplayName = "Year of Manugacturing";
        public const string EngineModelDisplayName = "Engine Model";
        public const string EngineHorsePowerDisplayName = "Engine Horse Power";
        public const string FuelTypeDisplayName = "Fuel Type";
        public const string ModelDisplayName = "Model";
        public const string ManufacturersDisplayName = "Make";
        public const string RegistrationPlateDisplayName = "Registration Plate";
        public const string PhoneNumberDisplayName = "Phone Number";

        //Parts
        public const int PartNameMinLength = 4;
        public const int PartNameMaxLength = 60;
        public const int PartNumberMinLength = 6;
        public const int PartNumberMaxLength = 25;
        public const double PartPriceMinValue = 0.1;
        public const double PartPriceMaxValue = 50000;

        //Parts error messages
        public const string PartPriceErrorMessage = "Price must be greater than {1}!";
    }
}
