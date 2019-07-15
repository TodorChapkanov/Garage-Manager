using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Admin.BindingModels.Part
{
    public class AddPartBindingModel
    {

        public string Name { get; set; }

        public string Number { get; set; }

        public decimal Price { get; set; }
    }
}
