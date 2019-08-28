using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Customer;
using GarageManager.Web.Models.ViewModels.Car;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GarageManager.Services.Tests
{
    public static class InitilizeAutoMapper
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
               typeof(CreateCarViewModel).GetTypeInfo().Assembly,
               typeof(CustomerDetails).GetTypeInfo().Assembly);

        }
    }
}
