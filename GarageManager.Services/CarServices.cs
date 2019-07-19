using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using GarageManager.Services.DTO.Car;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class CarServices : ICarServices
    {
        private readonly IDeletableEntityRepository<Car> carRepository;
        private readonly IDeletableEntityRepository<VehicleModel> modelServices;
        private readonly IDeletableEntityRepository<Department> departmentServices;
        private readonly IInterventionServices interventionService;

        public CarServices(
            IDeletableEntityRepository<Car> carRepository,
            IDeletableEntityRepository<VehicleModel> modelServices,
            IDeletableEntityRepository<Department> departmentServices,
            IInterventionServices interventionService)
        {
            this.carRepository = carRepository;
            this.modelServices = modelServices;
            this.departmentServices = departmentServices;
            this.interventionService = interventionService;
        }

        public async Task<IEnumerable<CustomerCarListDetails>> GetAllCarsByCustomerIdAsync(string id)
        {
            var result = await this.carRepository
                .All()
                .Include(car => car.Manufacturer)
                .Include(car => car.Model)
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

        public async Task<bool> CreateAsync<TEntity>
            (
            string customerId,
            string vin,
            string registrationPLate,
            string manufactirerId,
            string modelName,
            int kilometers, DateTime yearOfManufacture,
            string engineModel,
            int enginePower, string fuelTypeId,
            string transmissionId)

        {

            var modelId = (await this.modelServices.All().FirstOrDefaultAsync(model => model.Name == modelName)).Id;
            var carFromDb = new Car();
            try
            {
                carFromDb.CustomerId = customerId;
                carFromDb.Vin = vin;
                carFromDb.RegistrationPlate = registrationPLate;
                carFromDb.ManufactureId = manufactirerId;
                carFromDb.ModelId = modelId;
                carFromDb.Кilometers = kilometers;
                carFromDb.YearOfManufacture = yearOfManufacture;
                carFromDb.EngineModel = engineModel;
                carFromDb.EngineHorsePower = enginePower;
                carFromDb.FuelTypeId = fuelTypeId;
                carFromDb.TransmissionId = transmissionId;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid Car date");
                //TODO make constant 

            }


            await this.carRepository.CreateAsync(carFromDb);
            return true;
        }

        public async Task<CustomerCarDetails> GetDetailsByIdAsync(string id)
        {
            var carFromDb = this.carRepository.All()
                .Include(car => car.Manufacturer)
                .Include(car => car.Model)
                .Include(car => car.Customer)
                .Include(car => car.FuelType)
                .Include(car => car.Transmission);


            var result = await carFromDb
                .Where(car => car.Id == id)
                .Select(car => new CustomerCarDetails
                {
                    Id = car.Id,
                    CustomerId = car.CustomerId,
                    Make = car.Manufacturer.Name,
                    Model = car.Model.Name,
                    RegistrationPlate = car.RegistrationPlate,
                    Vin = car.Vin,
                    ManufacturedOn = car.YearOfManufacture,
                    Кilometers = car.Кilometers,
                    EngineModel = car.EngineModel,
                    EngineHorsePower = car.EngineHorsePower,
                    FuelType = car.FuelType.Type,
                    Transmission = car.Transmission.Type

                }).SingleOrDefaultAsync();


            return result;
        }

        public async Task<bool> UpdateCarByIdAsync(
            string id,
            string registrationPlate,
            int kilometers,
            DateTime yearOfManufacturing,
            string engineModel,
            int engineHorsePower,
            string fuelTypeId,
            string transmissionId)
        {
            try
            {
                var carFromDb = await this.carRepository.All().FirstOrDefaultAsync(car => car.Id == id);

                carFromDb.RegistrationPlate = registrationPlate;
                carFromDb.Кilometers = kilometers;
                carFromDb.YearOfManufacture = yearOfManufacturing;
                carFromDb.EngineModel = engineModel;
                carFromDb.EngineHorsePower = engineHorsePower;
                carFromDb.FuelTypeId = fuelTypeId;
                carFromDb.TransmissionId = transmissionId;

                await this.carRepository.UpdateAsync(carFromDb);
            }

            catch (Exception)
            {
                throw new InvalidOperationException("Invalid Car Details!");
            }

            return true;
        }

        public async Task<bool> AddToService(string carId, string carDescription, string departmentId)
        {
            try
            {
                var carFromDb = await this.carRepository.All().FirstOrDefaultAsync(car => car.Id == carId);
                var departmentFromDb = await this.departmentServices.All().FirstOrDefaultAsync(department => department.Id == departmentId);
                carFromDb.Description = carDescription;
                carFromDb.DepartmentId = departmentFromDb.Id;
                carFromDb.IsInService = true;
                await this.carRepository.UpdateAsync(carFromDb);

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<CarServicesDetails> GetCarServicesAsync(string id)
        {
            var carServices = await this.carRepository
                .All()
                .Where(car => car.Id == id)
                .Include(car => car.Manufacturer)
                .Include(car => car.Model)
                .Include(car => car.Services)
               // .ThenInclude(service => service.Parts)
               // .Include(services => services.Services.Repairs)
                .Select(car => new CarServicesDetails
                {
                    Id = car.Id,
                    Make = car.Manufacturer.Name,
                    Model = car.Model.Name,
                    RegisterPlate = car.RegistrationPlate,
                    Description = car.Description,
                    Parts = car.Services.Parts.Select(part => new PartDetails
                    {
                        Id = part.Id,
                        Name = part.Name,
                        Number = part.Number,
                        Price = part.Price,
                        Quantity = part.Quantity,
                        TotalCost = part.TotalCost
                    }),
                    Repairs = car.Services.Repairs.Select(repair => new RepairDetails
                    {
                        Id = repair.Id,
                        Description = repair.Description,
                        Hours = repair.Hours,
                        PricePerHour = repair.PricePerHour,
                        TotalCosts = repair.TotalCosts,
                        IsFinished = repair.IsFinished
                    })

                }).FirstOrDefaultAsync();

            return carServices;
        }

      
        public async Task<int> HardDeleteAsync(string id)
        {
            var carFromDb = await this.carRepository.All()
                .Include(service => service.Services)
                .FirstOrDefaultAsync(car => car.Id == id);

            await this.interventionService.HardDeleteAllAsync(carFromDb.Id);

             this.carRepository.HardDelete(carFromDb);

            return int.MaxValue;
        }
    }
}
