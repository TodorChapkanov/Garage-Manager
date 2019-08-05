﻿using GarageManager.Web.Views.Shared.Components.Models;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace GarageManager.Web.Views.Shared.Components.FuelTypes
{
    public class FuelTypesViewComponent : ViewComponent
    {
        private readonly IFuelTypeService fuelTypeService;

        public FuelTypesViewComponent(IFuelTypeService fuelTypeService)
        {
            this.fuelTypeService = fuelTypeService;
        }

        public IViewComponentResult Invoke()
        {
            
                var fuelTypes = new FuelTypeModel
                {
                    FuelTypes = this.fuelTypeService
                   .GetAllTypesAsync()
                   .Result
                   .OrderBy(m => m.Type)
                   .Select(m => new SelectListItem
                   {
                       Text = m.Type,
                       Value = m.Id
                   }).ToList()
                };

                return this.View("Default", fuelTypes);
        }
    }
}