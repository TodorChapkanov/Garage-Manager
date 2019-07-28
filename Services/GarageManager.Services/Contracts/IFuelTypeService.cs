using GarageManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
   public interface IFuelTypeService 
    {
        Task<IEnumerable<FuelType>> GetAllTypesAsync();
    }
}
