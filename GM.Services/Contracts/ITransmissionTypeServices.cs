﻿using GM.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GM.Services.Contracts
{
    public interface ITransmissionTypeServices
    {
        Task<List<TransmissionType>> GetAllTypes();
    }
}