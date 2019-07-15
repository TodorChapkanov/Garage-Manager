﻿using GarageManager.Domain;
using GarageManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IDepartmentServices
    {
        Task<IEnumerable<DepartmentAll>> AllDepartments();

        Task<DepartmentAllCars> GetDepartmentCars(string id);

        Task<CarServicesDetails> GetCarServicesAsync(string id);

        Task<Department> GetByIdAsync(string departmentId);
    }
}