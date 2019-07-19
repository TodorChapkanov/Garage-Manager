using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
   public  interface IInterventionServices
    {
        Task<int> HardDeleteAllAsync(string carId);
    }
}
