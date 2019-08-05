namespace GarageManager.Common.GlobalConstant
{
    public class CarConstants
    {
        public const int CarVinNumberMaxLength = 17;
        public const int CarMinKilometers = 0;
        public const int CarMaxKilometers = 10000000;
        public const int CarMinYearOfManufactorer = 1886;
        public const int CarMaxEngineHorsePower = 5000;
        public const int CarMinEngineHorsePower = 15;
        public const int CarMaxEngineModelLength = 20;
        public const int CarRegistrationPlateMaxLenth = 10;
        public const int CarRegistrationPlateMinLenth = 4;
        public const string CarRegistrationPlateErrorMassege = "Invalid Registration Plate";
        public const int CarDescriptionMaxLength = 500;
        public const int CarDescriptionMinLength = 10;
        public const string CarDescriptionErrorMessage = "The {0} must be between {2} and {1} symbols!";

    }
}
