using GM.Domain;
using System.Collections.Generic;

namespace GM.Services.DTO
{
    public class AllDateForCar
    {

        public VehicleManufacturer Manufacturer { get; set; }



        public VehicleModel Model { get; set; }



        public ICollection<FuelType> FuelTypes { get; set; }

        public ICollection<TransmissionType> TransmissionTypes { get; set; }

        

    }
}
