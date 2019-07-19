using GarageManager.Services.DTO.Part;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IPartsServices
    {
        Task<string> CreatePartAsync(
            string carId, 
            string name, 
            string number, 
            decimal price,
            int quantity);

        Task<PartEditDetils> GetEditDetailsByIdAsync(string id);

        Task<bool> UpdatePartByIdAsync(
            string id,
            string name,
            string number,
            decimal price,
            int quantity);

        Task<int> HardDeleteAsync(string id);
    }
}
