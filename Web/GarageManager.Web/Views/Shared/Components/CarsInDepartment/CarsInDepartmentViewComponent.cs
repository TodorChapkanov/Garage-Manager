using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Charts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GarageManager.Web.Views.Shared.Components.CarsInDepartment
{
    public class CarsInDepartmentViewComponent : ViewComponent
    {
        private readonly IDepartmentService departmentService;

        public CarsInDepartmentViewComponent(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        public  IViewComponentResult Invoke()
        {
            var carHistory = this.departmentService.GetCarsInDepartments().GetAwaiter().GetResult().OrderBy(dep => dep.DimensionOne);
            var model = new DepartmentChartViewModel
            {
                XLabels = Newtonsoft.Json.JsonConvert.SerializeObject(carHistory.Select(x => x.DimensionOne).ToList()),
                YValues = Newtonsoft.Json.JsonConvert.SerializeObject(carHistory.Select(x => x.Quantity).ToList())
            };

            return this.View(WebConstants.ViewComponentDefault, model);
        }
    }
}
