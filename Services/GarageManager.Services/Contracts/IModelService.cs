using GarageManager.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IModelService
    {
        Task<IEnumerable<string>> GetAllByMakeIdAsync(string id);


    }
}
