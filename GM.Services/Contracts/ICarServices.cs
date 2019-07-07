using System.Linq;

namespace GM.Services.Contracts
{
    public interface ICarServices
    {
        IQueryable<object> GetAll();
    }
}
