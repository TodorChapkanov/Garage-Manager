using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GarageManager.DAL.Contracts;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GarageManager.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository carRepository;
        private readonly IModelServices modelServices;
        private readonly IDepartmentServices departmentServices;

        public CarServices(ICarRepository carRepository, IModelServices modelServices, IDepartmentServices departmentServices)
        {
            this.carRepository = carRepository;
            this.modelServices = modelServices;
            this.departmentServices = departmentServices;
        }

        public async Task<IEnumerable<Car>> GetAllByCustomerIdAsync(string id)
        {
            var result = await this.carRepository.GetAllCarsByCustomerId(id).ToListAsync();
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

            var modelId = (await this.modelServices.GetByNameAsync(modelName)).Id;
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


            await this.carRepository.CreateNewAsync(carFromDb);
            return true;
        }

        public async Task<CustomerCarDetails> GetDetailsByIdAsync(string id)
        {
            var carFromDb = this.carRepository.GetAll()
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
            string transmissionId )
        {
            try
            {
                var carFromDb = await this.carRepository.GetByIdAsync(id);

                carFromDb.RegistrationPlate = registrationPlate;
                carFromDb.Кilometers = kilometers;
                carFromDb.YearOfManufacture = yearOfManufacturing;
                carFromDb.EngineModel = engineModel;
                carFromDb.EngineHorsePower = engineHorsePower;
                carFromDb.FuelTypeId = fuelTypeId;
                carFromDb.TransmissionId = transmissionId;

               await this.carRepository.UpdateCarAsync(carFromDb);
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
                var carFromDb = await this.carRepository.GetByIdAsync(carId);
                var departmentFromDb = await this.departmentServices.GetByIdAsync(departmentId);
                carFromDb.Description = carDescription;
                carFromDb.DepartmentId = departmentFromDb.Id;
                await this.carRepository.UpdateCarAsync(carFromDb);

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
