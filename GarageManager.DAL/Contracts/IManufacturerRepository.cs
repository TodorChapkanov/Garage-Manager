using GarageManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageManager.DAL.Contracts
{
   public interface IManufacturerRepository :IRepository<VehicleManufacturer>
    {
        IQueryable<VehicleManufacturer>  GetAll();

       
    }
}
