using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Service;
using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Web.Models.ViewModels.ServiceIntervention
{
    public class CompletedCarServiceDetailsViewModel :IMapFrom<CompletedCarServiceDetails>
    {

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegistrationPlate { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerEmail { get; set; }

        public IEnumerable<CarServiceHistoryPartDetailsViewModel> ServicesParts { get; set; }

        public IEnumerable<CarServiceHistoryRepairDetailsViewModel> ServicesRepairs { get; set; }
    }
}
