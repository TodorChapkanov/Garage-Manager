﻿using GarageManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IModelServices
    {
        Task<IEnumerable<string>> GetAllByMakeIdAsync(string id);

        Task<VehicleModel> GetByNameAsync(string name);

    }
}