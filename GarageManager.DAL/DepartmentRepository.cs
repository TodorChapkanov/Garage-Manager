using System.Linq;
using System.Threading.Tasks;
using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace GarageManager.DAL
{
    public class DepartmentRepository : RepositoryBase<Department,string> , IDepartmentRepositoty
    {
        public DepartmentRepository(GMDbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Department> GetAll()
        {
            var result =  base.All();
            return result;
        }

        public async Task<Department> GetByIdAsync(string id)
        {
            var departmentFromDb = await base.GetAsync(id);
            return departmentFromDb;
        }

        public async Task<IQueryable<Department>> GetAllCarsInDepartment(string id)
        {
          var departmentFromDb =   this.All()
                .Where(department => department.Id == id)
                .Include(cars => cars.Cars);

            return departmentFromDb;
        }
    }
}
