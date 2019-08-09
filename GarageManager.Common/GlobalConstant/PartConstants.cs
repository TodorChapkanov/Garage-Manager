namespace GarageManager.Common.GlobalConstant
{
    public class PartConstants
    {
        public const int PartNameMinLength = 4;
        public const int PartNameMaxLength = 60;
        public const int PartNumberMinLength = 6;
        public const int PartNumberMaxLength = 25;
        public const int PartQuantityMinRange = 1;
        public const int PartQuantityMaxRange = int.MaxValue;
        public const string PartQuantityErrorMessage = "{0} must be greater or equal to {1}";
        public const double PartPriceMinValue = 0.1;
        public const double PartPriceMaxValue = 20000;
        public const string PartPriceErrorMessage = "{0} must be greater than {1}!";
    }
}
