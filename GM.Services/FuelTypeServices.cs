using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.DAL.Contracts;
using GM.Domain;
using GM.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GM.Services
{
    public class FuelTypeServices : IFuelTypeServices
    {
        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeServices(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }

        public ICollection<FuelType> GetAllTypes()
        {
            var result = fuelTypeRepository.GetAllFuelTypes().ToList();

            return result;
        }
    }
}
