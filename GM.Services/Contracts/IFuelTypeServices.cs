using GM.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GM.Services.Contracts
{
   public interface IFuelTypeServices 
    {
        ICollection<FuelType> GetAllTypes();
    }
}
