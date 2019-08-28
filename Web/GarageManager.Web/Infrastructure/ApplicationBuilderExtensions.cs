using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.Common.GlobalConstant;
using GarageManager.Data;
using GarageManager.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace GarageManager.Web.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedData(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var dbContext = serviceScope.ServiceProvider.GetService<GMDbContext>();

                if (dbContext.Database.GetPendingMigrations().Any())
                {
                    dbContext.Database.Migrate();

                    SeedRequiredData(dbContext);
                    SeedOptionalData(serviceScope, dbContext);
                }


            }

            return app;
        }

        private static void SeedRequiredData(GMDbContext dbContext)
        {

            SeedManufacturers(dbContext);
            SeedModels(dbContext);
            SeedCustomers(dbContext);
            SeedFuelTypes(dbContext);
            SeedTransmissionTypes(dbContext);
            SeedDepartments(dbContext);


        }

        private static void SeedOptionalData(IServiceScope serviceScope, GMDbContext dbContext)
        {
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<GMUser>>();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            SeedDefaultRoles(userManager, roleManager, dbContext);
            SeedCars(dbContext);
        }

        private static void SeedDefaultRoles(UserManager<GMUser> userManager, RoleManager<IdentityRole> roleManager, GMDbContext dbContext)
        {


            Task
               .Run(async () =>
               {
                   var roles = new[]
                   {
                         RoleConstants.AdministratorRoleName,
                            RoleConstants.EmployeeRoleName
                   };

                   foreach (var role in roles)
                   {
                       var roleExist = await roleManager.RoleExistsAsync(role);

                       if (!roleExist)
                       {
                           await roleManager.CreateAsync(new IdentityRole(role));
                       }
                   }

               }).GetAwaiter().GetResult();
        }

        private static void SeedCars(GMDbContext dbContext)
        {
            var random = new Random();
            var customerIds = dbContext.Customers
                .OrderBy(customer => customer.FullName)
                .Select(customer => customer.Id)
                .Take(SeedConstants.CountOfCustomersToSeedWithCars)
                .ToList();

            var fuelTypes = dbContext.FuelTypes
                .Select(type => type.Id)
                .ToList();

            var transmissionTypes = dbContext.TransmissionTypes
                .Select(type => type.Id)
                .ToList();

            var manufactuters = dbContext.VehicleManufacturers
                .ToList(); ;

            var models = dbContext.VehicleModels
                .ToList();

            var vins = GetCarVins();

            var registrationPlates = GetCarRegistrationPlates();

            var horsePowerValues = GetCarEngineHorsePowerValues();



            var yearsOfManufacturing = GetCarYearsOfManufacturing();

            var engineModels = GetCarEnginModels();

            var kilometValues = GetCarKilometersValues();



            var cars = new List<Car>();
            var services = new List<ServiceIntervention>();

            foreach (var customerId in customerIds)
            {
                for (int i = 0; i < 20; i++)
                {
                    var manufacturer = manufactuters[random.Next(0, manufactuters.Count - 1)];
                    var manufacturerModels = models
                        .Where(m => m.ManufactirerId == manufacturer.Id)
                        .ToList();
                    if (!manufacturerModels.Any())
                    {
                        continue;
                    }
                    var model = manufacturerModels[random.Next(0, manufacturerModels.Count - 1)];
                    var fuelTypeId = fuelTypes[random.Next(0, fuelTypes.Count)];
                    var transmissionId = transmissionTypes[random.Next(0, transmissionTypes.Count - 1)];
                    var registrationPLate = registrationPlates[random.Next(0, registrationPlates.Count - 1)];
                    var yearOfManufacturing = yearsOfManufacturing[random.Next(0, yearsOfManufacturing.Count - 1)];
                    var vin = vins[random.Next(0, vins.Count - 1)];
                    var horsePoerValue = horsePowerValues[random.Next(0, horsePowerValues.Count - 1)];
                    var engineModel = engineModels[random.Next(0, engineModels.Count - 1)];
                    var kilometerVaue = kilometValues[random.Next(0, kilometValues.Count - 1)];
                    var service = new ServiceIntervention();


                    var car = new Car
                    {
                        CustomerId = customerId,
                        Vin = vin,
                        RegistrationPlate = registrationPLate,
                        MakeId = manufacturer.Id,
                        ModelId = model.Id,
                        FuelTypeId = fuelTypeId,
                        TransmissionId = transmissionId,
                        YearOfManufacturing = yearOfManufacturing,
                        EngineHorsePower = horsePoerValue,
                        EngineModel = engineModel,
                        Кilometers = kilometerVaue,
                        ServiceId = service.Id
                    };

                    service.CarId = car.Id;
                    cars.Add(car);
                    services.Add(service);
                }
            }
            dbContext.ServiceInterventions.AddRange(services);
            dbContext.Cars.AddRange(cars);
            dbContext.SaveChanges();
        }



        private static void SeedDepartments(GMDbContext dbContext)
        {
            var departmentList = new List<Department>
           {
               new Department
               {
                   Name = SeedConstants.BodyRepair
               },

               new Department
               {
                   Name = SeedConstants.FacilitiesManagement
               },

               new Department
               {
                   Name = SeedConstants.MechanicalRepair
               },

               new Department
               {
                   Name = SeedConstants.Painting
               }
           };

            dbContext.Departments.AddRange(departmentList);
            dbContext.SaveChanges();
        }

        private static void SeedModels(GMDbContext dbContext)
        {
            var modelList = File
                  .ReadAllText(SeedConstants.CarModelDataPath);

            var models = JsonConvert.DeserializeObject<VehicleModel[]>(modelList);

            dbContext.VehicleModels.AddRange(models);
            dbContext.SaveChanges();
        }

        private static void SeedCustomers(GMDbContext dbContext)
        {
            var customerList = File
                  .ReadAllText(SeedConstants.CustomerDataPath);

            var customers = JsonConvert.DeserializeObject<Customer[]>(customerList);

            dbContext.Customers.AddRange(customers);
            dbContext.SaveChanges();
        }


        private static void SeedTransmissionTypes(GMDbContext dbContext)
        {
            var transmissionTypes = new List<TransmissionType>
            {
              new TransmissionType
              {
                  Name = SeedConstants.Manual
              },

              new TransmissionType
              {
                  Name = SeedConstants.SemiAutomatic
              },

              new TransmissionType
              {
                  Name= SeedConstants.DirectShiftGearbox
              },

              new TransmissionType
              {
                  Name = SeedConstants.Automatic

              }
            };

            dbContext.TransmissionTypes.AddRange(transmissionTypes);
            dbContext.SaveChanges();
        }

        private static void SeedFuelTypes(GMDbContext dbContext)
        {
            var fuelTypes = new List<FuelType>
            {
                new FuelType
                {
                    Name = SeedConstants.FuelTypeBioDiesel
                },

                new FuelType
                {
                    Name = SeedConstants.FuelTypeCNG
                },

                new FuelType
                {
                    Name = SeedConstants.FuelTypeDiesel
                },

                new FuelType
                {
                    Name = SeedConstants.FuelTypeElectricity
                },

                new FuelType
                {
                    Name = SeedConstants.FuelTypeGasoline
                },

                new FuelType
                {
                    Name = SeedConstants.FuelTypeHydrogen
                },

                new FuelType
                {
                    Name = SeedConstants.FuelTypeLPG
                }
            };

            dbContext.FuelTypes.AddRange(fuelTypes);
            dbContext.SaveChanges();
        }

        private static void SeedManufacturers(GMDbContext dbContext)
        {
            var manufacturerList = File
                  .ReadAllText(SeedConstants.CarManufacturerDataPath);

            var manufacturerTypes = JsonConvert.DeserializeObject<VehicleManufacturer[]>(manufacturerList);

            dbContext.VehicleManufacturers.AddRange(manufacturerTypes);
            dbContext.SaveChanges();
        }

        private static List<string> GetCarVins()
        {
            var list = new List<string>
            {
                    "1FTMF1E84AK230499",
                    "1C4SDJCT3CC747474",
                    "JN1CV6FE9AM787080",
                    "SALGS2DF8DA933561",
                    "5UMCN93492L160120",
                    "1C4PJLAB6FW521145",
                    "3N1CN7AP3DL584733",
                    "1HGCR2E77EA630475",
                    "JA32U1FU5AU769566",
                    "1FTEX1C84AK320496",
                    "WA1LFBFP0EA463859",
                    "JTHBF1D27F5669370",
                    "WBAPT73509C077661",
                    "1GKS1KE03ER753197",
                    "WAUKF98E56A055393",
                    "WAUHE78P19A783994",
                    "WVWBN7AN4FE348067",
                    "5NPET4AC8AH454417",
                    "WAULD64BX2N962499",
                    "1GYS3CEF4CR854837",
                    "WBADT33401G278864",
                    "3FAHP0CG3AR363391",
                    "1G4HP57M89U061084"
            };

            return list;
        }

        private static List<string> GetCarRegistrationPlates()
        {
            var list = new List<string>
            {
                "AA 1111 AA",
                "BB 2222 BB",
                "CC 3333 CC",
                "DD 4444 DD",
                "EE 5555 EE",
                "FF 6666 FF"
                };

            return list;
        }

        private static List<int> GetCarEngineHorsePowerValues()
        {
            var list = new List<int>();
            for (int i = SeedConstants.StartHorsePowerIndex; i < SeedConstants.EndHorsePowerIndex; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static List<int> GetCarYearsOfManufacturing()
        {
            var list = new List<int>();

            for (int i = SeedConstants.StartYearOfManufacturing; i < DateTime.Now.Year; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private static List<string> GetCarEnginModels()
        {
            var list = new List<string>
            {
                "1.0",
                "1.1",
                "1.2",
                "1.4",
                "1.6",
                "1.8",
                "1.9",
                "2.0",
                "2.2",
                "2.4"
            };

            return list;
        }

        private static List<int> GetCarKilometersValues()
        {
            var list = new List<int>();

            for (int i = SeedConstants.KilometersStartValue; i < SeedConstants.KilometersEndValue; i++)
            {
                list.Add(i);
            }

            return list;
        }
    }
}
