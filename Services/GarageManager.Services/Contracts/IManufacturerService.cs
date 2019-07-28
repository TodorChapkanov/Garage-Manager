using GarageManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IManufacturerService
    {
        Task<IEnumerable<VehicleManufacturer>> GetAllAsync();
    }
}
