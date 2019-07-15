using GarageManager.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
   public interface IFuelTypeServices 
    {
        Task<IEnumerable<FuelType>> GetAllTypesAsync();
    }
}
