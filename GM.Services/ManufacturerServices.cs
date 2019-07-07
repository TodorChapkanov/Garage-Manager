using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.DAL;
using GM.DAL.Contracts;
using GM.Domain;
using GM.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GM.Services
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly IManufacturerRepository repository;

        public ManufacturerServices(IManufacturerRepository repository)
        {
            this.repository = repository;
        }

        public ICollection<VehicleManufacturer> GetAll()
        {
            var result = this.repository.GetAll().ToList();

            return result;
        }
    }
}
