using GarageManager.Common.GlobalConstant;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using GarageManager.Services.DTO.Car;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class CarService : BaseService, ICarService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IModelService modelServices;
        private readonly IInterventionService serviceIntervention;

        public CarService(
            IDeletableEntityRepository<Car> carRepository,
            IModelService modelServices,
            IInterventionService serviceIntervention)
        {
            this.carRepository = carRepository;
            this.modelServices = modelServices;
            this.serviceIntervention = serviceIntervention;
        }

        public async Task<IEnumerable<CustomerCarListDetails>> GetAllCarsByCustomerIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var result = await this.carRepository
                    .All()
                    .Where(customer => customer.CustomerId == id)
                    .Select(car => new CustomerCarListDetails
                    {
                        Id = car.Id,
                        Make = car.Manufacturer.Name,
                        Model = car.Model.Name,
                        RegistrationPlate = car.RegistrationPlate,
                        IsInService = car.IsInService
                    })
                    .ToListAsync();
                return result;
            }
            catch
            {
                return null;
            }
            
        }

        public async Task<bool> CreateAsync
            (
            string customerId,
            string vin,
            string registrationPLate,
            string manufactirerId,
            string modelName,
            int kilometers,
            int yearOfManufacture,
            string engineModel,
            int engineHorsePower,
            string fuelTypeId,
            string transmissionId)

        {
            try
            {
                var modelId = (await this.modelServices.GetByNameAsync(modelName)).Id;
                var service = new ServiceIntervention();
                var car = new Car
                {

                    CustomerId = customerId,
                    Vin = vin,
                    RegistrationPlate = registrationPLate,
                    ManufacturerId = manufactirerId,
                    ModelId = modelId,
                    Кilometers = kilometers,
                    YearOfManufacturing = yearOfManufacture,
                    EngineModel = engineModel,
                    EngineHorsePower = engineHorsePower,
                    FuelTypeId = fuelTypeId,
                    TransmissionId = transmissionId,
                    CurrentServiceId = service.Id,
                };

                car.Services.Add(service);

                this.ValidateEntityState(car);
               var result=  await this.carRepository.CreateAsync(car);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<CustomerCarDetails> GetCarDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
 


                var result = await this.carRepository
                    .All()
                    .Where(car => car.Id == id)
                    .Select(car => new CustomerCarDetails
                    {
                        Id = car.Id,
                        CustomerId = car.CustomerId,
                        Make = car.Manufacturer.Name,
                        Model = car.Model.Name,
                        RegistrationPlate = car.RegistrationPlate,
                        Vin = car.Vin,
                        ManufacturedOn = car.YearOfManufacturing,
                        Кilometers = car.Кilometers,
                        EngineModel = car.EngineModel,
                        EngineHorsePower = car.EngineHorsePower,
                        FuelType = car.FuelType.Type,
                        Transmission = car.Transmission.Type

                    }).SingleOrDefaultAsync();


                return result;
            }
            catch 
            {
               return null;
            }
            
        }

        public async Task<int> UpdateCarByIdAsync(
            string id,
            string registrationPlate,
            int kilometers,
            int yearOfManufacturing,
            string engineModel,
            int engineHorsePower,
            string fuelTypeId,
            string transmissionId)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var carFromDb = await this.carRepository.All()
                    .FirstOrDefaultAsync(car => car.Id == id);

                carFromDb.RegistrationPlate = registrationPlate;
                carFromDb.Кilometers = kilometers;
                carFromDb.YearOfManufacturing = yearOfManufacturing;
                carFromDb.EngineModel = engineModel;
                carFromDb.EngineHorsePower = engineHorsePower;
                carFromDb.FuelTypeId = fuelTypeId;
                carFromDb.TransmissionId = transmissionId;

                this.ValidateEntityState(carFromDb);

              return  await this.carRepository.Update(carFromDb);
               
            }
            catch
            {
                return default(int);
            }
        }

        public async Task<int> AddToServiceAsync(string carId, string carDescription, string departmentId)
        {
            try
            {
                this.ValidateNullOrEmptyString(carId, carDescription, departmentId);
                this.ValidateStringLength(
                    carDescription,
                    CarConstants.CarDescriptionMinLength,
                    CarConstants.CarDescriptionMaxLength
                    );

                var carFromDb = await this.carRepository.All().FirstOrDefaultAsync(car => car.Id == carId);
                carFromDb.Description = carDescription;
                carFromDb.DepartmentId = departmentId;
                carFromDb.IsInService = true;
                return await this.carRepository.Update(carFromDb);

            }
            catch 
            {
                return default(int);
            }
        }
        public async Task<CarServicesDetails> GetCarServiceDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);

                var carServices = await this.carRepository
               .All()
               .Where(car => car.Id == id)
               .Select(car => new CarServicesDetails
               {
                   Id = car.Id,
                   Make = car.Manufacturer.Name,
                   Model = car.Model.Name,
                   RegisterPlate = car.RegistrationPlate,
                   Description = car.Description,
                   DepartmentId = car.DepartmentId,
                   Parts = car.Services.First(service => service.Id == car.CurrentServiceId).Parts.Select(part => new PartDetails
                   {
                       Id = part.Id,
                       Name = part.Name,
                       Number = part.Number,
                       Price = part.Price,
                       Quantity = part.Quantity,
                       TotalCost = part.TotalCost
                   }).ToList(),
                   Repairs = car.Services.First(service => service.Id == car.CurrentServiceId).Repairs.Select(repair => new RepairDetails
                   {
                       Id = repair.Id,
                       Description = repair.Description,
                       Hours = repair.Hours,
                       PricePerHour = repair.PricePerHour,
                       TotalCosts = repair.TotalCosts,
                       IsFinished = repair.IsFinished
                   }).ToList()

               }).FirstOrDefaultAsync();

                return carServices;
            }
            catch 
            {
                return null;
            }
           
        }


        public async Task<int> HardDeleteAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var carFromDb = await this.carRepository.GetEntityByKeyAsync(id);

                return await this.carRepository.HardDelete(carFromDb);
                
            }
            catch 
            {
                return default(int);
            }
            

           
        }

        public async Task<CarServiceDetails> GetServiceDescriptionByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var carFromDb = await this.carRepository.GetEntityByKeyAsync(id);
                var result = new CarServiceDetails
                {
                    Description = carFromDb.Description,
                    DepartmentId = carFromDb.DepartmentId
                };

                return result;
            }
            catch
            {
                return null;
            }
           
        }

        public async Task<int> FinishCarServiceAsync(string carId)
        {
            try
            {
                this.ValidateNullOrEmptyString(carId);

                var carFromDb = await this.carRepository.GetEntityByKeyAsync(carId);
                carFromDb.IsFinished = true;
                carFromDb.IsInService = false;
                carFromDb.DepartmentId = null;

               return await this.carRepository.Update(carFromDb);
            }
            catch 
            {
                return default(int);
            }
           
        }

        public async Task<List<CompletedCarList>> CompletedCarsListAsync()
        {
            var result = await this.carRepository
             .All()
             .Where(car => car.IsFinished)
             .Select(car => new CompletedCarList
             {
                 Id = car.Id,
                 Make = car.Manufacturer.Name,
                 Model = car.Model.Name,
                 RegisterPlate = car.RegistrationPlate
             })
             .ToListAsync();

            return result;
        }

        public async Task<string> CompleteTheOrderByCarIdAsync(string carId)
        {
            try
            {
                this.ValidateNullOrEmptyString(carId);

                var carFromDb = await this.carRepository
                .All()
                .Include(car => car.Services)
                .FirstOrDefaultAsync(car => car.Id == carId);

               var serviceResult = await this.serviceIntervention.FinishServiceAsync(carFromDb.CurrentServiceId);

                if (serviceResult == default(int))
                {
                    return null;
                }

                var newService = new ServiceIntervention();
                carFromDb.IsFinished = false;
                carFromDb.Description = default;
                carFromDb.CurrentServiceId = newService.Id;
                carFromDb.Services.Add(newService);
                await this.carRepository.SavaChangesAsync();
                return carFromDb.CustomerId;
            }
            catch 
            {

                return null;
            }
            
        }
    }
}
