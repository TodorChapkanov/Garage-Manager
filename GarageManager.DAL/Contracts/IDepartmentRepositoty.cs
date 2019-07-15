using GarageManager.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.DAL.Contracts
{
    public interface IDepartmentRepositoty 
    {
        IQueryable<Department> GetAll();


        Task<Department> GetByIdAsync(string id);

        Task<IQueryable<Department>> GetAllCarsInDepartment(string id);
    }
}
