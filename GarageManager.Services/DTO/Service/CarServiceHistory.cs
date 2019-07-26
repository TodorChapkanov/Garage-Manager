using System;

namespace GarageManager.Services.DTO.Service
{
    public class CarServiceHistory
    {
        public string  Id { get; set; }

        public string  CarMake { get; set; }

        public string CarRegistrtionPlate { get; set; }

        public DateTime FinishedOn { get; set; }

        public decimal   Price { get; set; }
    }
}
