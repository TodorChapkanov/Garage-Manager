using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IRepairsServices
    {
        Task<string> CreateRepairService(string carId, string description, double hours, decimal pricePerHour);
    }
}
