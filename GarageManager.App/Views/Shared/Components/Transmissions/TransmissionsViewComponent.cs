﻿using GarageManager.App.Views.Shared.Components.Models;
using GarageManager.Services;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GarageManager.App.Views.Shared.Components.Transmissions
{
    public class TransmissionsViewComponent : ViewComponent
    {
        private readonly ITransmissionTypesServices transmissionTypeService;

        public TransmissionsViewComponent(ITransmissionTypesServices transmissionTypeService)
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
