using GarageManager.Services.DTO.Repair;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IRepairsServices
    {
        Task<string> CreateRepairService(string carId, string description, double hours, decimal pricePerHour);

        Task<bool> UpdatePartByIdAsync(
            string id,
            string description,
            double hours,
            decimal pricePerHour,
            bool isFinished);

        Task<RepairEditDetails> GetEditDetailsByIdAsync(string id);

        Task<int> HardDeleteAsync(string id);
    }
}
