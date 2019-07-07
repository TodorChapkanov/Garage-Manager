using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.DAL;
using GM.DAL.Contracts;
using GM.Domain;
using GM.Services.Contracts;

namespace GM.Services
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly IManufacturerRepository repository;

        public ManufacturerServices(IManufacturerRepository repository)
        {
            this.repository = repository;
        }

        public ICollection<VehicleManufacturer> GetAllAsync()
        {
            var result = this.repository.GetAll().ToList();

            return result;
        }
    }
}
