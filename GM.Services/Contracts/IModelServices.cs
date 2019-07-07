using System.Collections.Generic;
using System.Threading.Tasks;

namespace GM.Services.Contracts
{
    public interface IModelServices
    {
        Task<ICollection<string>> GetAllByMakeId(string id);
    }
}
