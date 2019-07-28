using GarageManager.Services.DTO.Part;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IPartsService
    {
        Task<string> CreatePartAsync(
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

        Task<string> HardDeleteAsync(string id);
    }
}
