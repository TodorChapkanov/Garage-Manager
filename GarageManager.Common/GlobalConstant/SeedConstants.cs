namespace GarageManager.Common.GlobalConstant
{
   public  class SeedConstants
    {
        public const string CustomerDataPath = @"SeedResources\customer-data.json";
        public const string CarManufacturerDataPath = @"SeedResources\manufacturer-data.json";
        public const string CarModelDataPath = @"SeedResources\model-data.json";
        public const int CountOfCustomersToSeedWithCars = 5;
        public const int StartYearOfManufacturing = 1980;
        public const int StartHorsePowerIndex = 100;
        public const int EndHorsePowerIndex = 2000;
        public const int KilometersStartValue = 0;
        public const int KilometersEndValue = 100000;

        //TransmisionTypes
        public const string Automatic = "Automatic";
        public const string SemiAutomatic = "Semi-automatic";
        public const string Manual = "Manual";
        public const string DirectShiftGearbox = "Direct shift gearbox";

        //FuelType
        public const string FuelTypeDiesel = "Diesel";
        public const string FuelTypeElectricity = "Electricity";
        public const string FuelTypeHydrogen = "Hydrogen";
        public const string FuelTypeCNG = "CNG";
        public const string FuelTypeBioDiesel = "Bio Diesel";
        public const string FuelTypeGasoline = "Gasoline";
        public const string FuelTypeLPG = "LPG";

        //Departments

        public const string BodyRepair = "Body Repair";
        public const string Painting = "Painting";
        public const string FacilitiesManagement = "Facilities Management";
        public const string MechanicalRepair = "Mechanical Repair";
    }
}
