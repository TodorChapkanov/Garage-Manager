using GarageManager.Services.Models.Part;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IPartService
    {
        Task<string> CreateAsync(
            string carId, 
            string name, 
            string number, 
            decimal price,
            int quantity);

        Task<PartEditDetils> GetEditDetailsByIdAsync(string id);

        Task<int> UpdatePartByIdAsync(
            string id,
            string name,
            string number,
            decimal price,
            int quantity);

        Task<int> HardDeleteAsync(string id);
    }
}
