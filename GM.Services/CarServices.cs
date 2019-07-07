using System.Linq;
using System.Threading.Tasks;
using GM.DAL.Contracts;
using GM.Services.Contracts;
using GM.Services.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace GM.Services
{
    public class CarServices : ICarServices
    {
        private readonly ICarRepository repository;
        private readonly IManufacturerRepository manufacturerServices;

        public CarServices(ICarRepository repository, IManufacturerRepository manufacturerServices)
        {
            this.repository = repository;
            this.manufacturerServices = manufacturerServices;
        }

        public IQueryable<object> GetAll()
        {
          return null;
            
        }
    }
}
