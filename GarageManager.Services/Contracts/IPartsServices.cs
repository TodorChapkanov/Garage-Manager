using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IPartsServices
    {



        Task<string> CreatePart(string carId, string name, string number, decimal price);


    }
}
