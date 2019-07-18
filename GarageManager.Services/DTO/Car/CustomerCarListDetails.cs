using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.DTO.Car
{
    public class CustomerCarListDetails
    {
        public string Id { get; set; }

        public string RegistrationPlate { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public bool IsInService { get; set; }
    }
}
