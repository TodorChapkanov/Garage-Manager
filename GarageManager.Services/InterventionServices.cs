using GarageManager.Data.Repository;
using GarageManager.Domain;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class InterventionServices
    {
        private readonly IDeletableEntityRepository<Part> partRepository;
        private readonly IDeletableEntityRepository<ServicePart> servicePartRepository;

        public InterventionServices(IDeletableEntityRepository<Part> partRepository, IDeletableEntityRepository<ServicePart> servicePartRepository)
        {
            this.partRepository = partRepository;
            this.servicePartRepository = servicePartRepository;
        }
        public async Task<string> CreatePart(string name, string number, decimal price, string departmentId)
        {
            var part = new Part
            {
                Name = name,
                Number = number,
                Price = price,
                DepartmentId = departmentId
            };
            await this.partRepository.CreateAsync(part);

            return part.Id;
        }

        protected void AddPartToServiceParts(string partId, string serviceId)
        {
            this.servicePartRepository.CreateAsync (new ServicePart
            {
                PartId = partId,
                ServiceId = serviceId
            });
        }
    }
}
