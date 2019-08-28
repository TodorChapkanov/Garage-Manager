using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Service;
using System;

namespace GarageManager.Web.Models.ViewModels.ServiceIntervention
{
    public class CarServiceHistoryViewModel : IMapFrom<CarServiceHistory>
    {
        public string Id { get; set; }


        public string CarMake { get; set; }

        public string CarRegistrtionPlate { get; set; }

        public DateTime FinishedOn { get; set; }

        public decimal Price { get; set; }
    }
}
