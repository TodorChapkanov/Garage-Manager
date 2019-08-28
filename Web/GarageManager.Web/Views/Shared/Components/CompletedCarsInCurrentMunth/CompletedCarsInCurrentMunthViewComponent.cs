using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.Charts;
using GarageManager.Web.Models.ViewModels.Charts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageManager.Web.Views.Shared.Components.CompletedCarsInCurrentMunth
{
    public class CompletedCarsInCurrentMunthViewComponent : ViewComponent
    {
        private readonly IInterventionService interventionService;

        public CompletedCarsInCurrentMunthViewComponent(IInterventionService interventionService)
        {
            this.interventionService = interventionService;
        }

        public IViewComponentResult Invoke()
        {
            var lstModel = new List<SimpleReportViewModel>();

            var days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            var carHistory = this.interventionService.GetFinishedCarsForCurrentMunth();

            for (int i = 1; i < days+1; i++)
            {
                var report = new SimpleReportViewModel
                {
                    DimensionOne = i.ToString(),
                    Quantity = 0
                };
                if (carHistory.ContainsKey(i))
                {
                    report.Quantity = carHistory[i];
                }
                lstModel.Add(report);
            }

            var model = new FinishedCarsChartViewModel
            {
                XLabels = Newtonsoft.Json.JsonConvert.SerializeObject(lstModel.Select(x => x.DimensionOne).ToList()),
                YValues = Newtonsoft.Json.JsonConvert.SerializeObject(lstModel.Select(x => x.Quantity).ToList())
            };

            return this.View(WebConstants.ViewComponentDefault, model);
        }
    }
}
