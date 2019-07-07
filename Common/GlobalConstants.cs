namespace Common
{
    public class GlobalConstants
    {
        // Customer Form 
        public const int MinLengthCutomerName = 3;
        public const int MaxLengthCustomerName = 20;
        public const string CustomeNameLengthErrorMessage = "Name should be between {2} and {1} symbols!";
        public const int PasswordMinLength = 4;
        public const int PasswordMaxLrngth = 20;
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
        public  const int CarMinEngineHorsePower = 0;
        public  const int CarMaxEngineModelLength = 20;


        //Administrator Roles
        public const string AdministratorRoleName = "Admin";
        public const string ТinsmithDepartmentManagerRoleName = "TDM";
        public const string PaintingDepartmentManagerRoleName = "PDM";
        public const string MechanikDepartmentManagerRoleName = "MDM";
        public const string WarehouseDepartmentManagerRoleName = "WDM";

        public const string DefaultLogoutUrl = "/Home/Index";
    }
}
