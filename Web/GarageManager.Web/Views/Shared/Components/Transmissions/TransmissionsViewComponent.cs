using GarageManager.Web.Views.Shared.Components.Models;
using GarageManager.Services;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GarageManager.eb.Views.Shared.Components.Transmissions
{
    public class TransmissionsViewComponent : ViewComponent
    {
        private readonly ITransmissionTypesService transmissionTypeService;

        public TransmissionsViewComponent(ITransmissionTypesService transmissionTypeService)
        {
            this.transmissionTypeService = transmissionTypeService;
        }

        public IViewComponentResult Invoke()
        {
            var transmissions = new TransmissionModel
            {
                Transmissions = this.transmissionTypeService
               .GetAllTypesAsync()
               .Result
               .OrderBy(t => t.Type)
               .Select(t => new SelectListItem
               {
                   Text = t.Type,
                   Value = t.Id
               }).ToList()
            };

            return this.View("Default", transmissions);
        }
    }
}
