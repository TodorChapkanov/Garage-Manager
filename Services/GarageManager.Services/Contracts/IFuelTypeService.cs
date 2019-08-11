using GarageManager.Services.Models.FuelType;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IFuelTypeService 
    {
        Task<IEnumerable<FuelTypeDetails>> GetAllTypesAsync();
    }
}
