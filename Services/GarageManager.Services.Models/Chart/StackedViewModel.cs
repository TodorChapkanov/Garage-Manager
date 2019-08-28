using System;
using System.Collections.Generic;
using System.Text;

namespace GarageManager.Services.Models.Charts
{
    public class StackedViewModel
    {
        public string StackedDimensionOne { get; set; }
        public IEnumerable<SimpleReportViewModel> LstData { get; set; }
    }
}
