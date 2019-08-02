namespace GarageManager.Common.GlobalConstant
{
    public class RepairConstants
    {
        public const double MinRepairTime = 0.10;
        public const double MaxRepairTime = 120;
        public const string RepairTimeErrorMessage = "{0} must be greater or equal than {1} and less or equal {2}";
        public const int RepairDescriptionMinLength = 10;
        public const int RepairDescriptionMaxLength = 500;
        public const double RepairMinPricePerHour = 1.00;
        public const double RepairMaxPricePerHour = double.MaxValue;
        public const string RepairPricePerHourErrorMessage = "{0} must be greater or equal than {1} and less or equal {2}";

    }
}
