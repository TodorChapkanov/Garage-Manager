﻿using GarageManager.Services.DTO.Repair;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IRepairsService
    {
        Task<string> CreateRepairService(
            string carId,
            string description,
            double hours,
            decimal pricePerHour,
            string emplyeeId);

        Task<int> UpdateRepairByIdAsync(
            string id,
            string description,
            double hours,
            decimal pricePerHour,
            bool isFinished);

        Task<RepairEditDetails> GetEditDetailsByIdAsync(string id);

        Task<int> HardDeleteAsync(string id);
    }
}
