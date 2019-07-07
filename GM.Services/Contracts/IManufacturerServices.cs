using GM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Services.Contracts
{
    public interface IManufacturerServices
    {
       ICollection<VehicleManufacturer> GetAllAsync();
    }
}
