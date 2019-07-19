using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class InterventionServices : IInterventionServices
    {
        private readonly IDeletableEntityRepository<ServiceIntervention> serviceRepository;
        private readonly IPartsServices partService;
        private readonly IRepairsServices repairsService;

        public InterventionServices(IDeletableEntityRepository<ServiceIntervention> serviceRepository,
            IPartsServices partService,
            IRepairsServices repairsService)
        {
            this.serviceRepository = serviceRepository;
            this.partService = partService;
            this.repairsService = repairsService;
        }

        public async Task<int> HardDeleteAllAsync (string carId)
        {
            
            try
            {
                var serviceFromDb = await this.serviceRepository.All()
                   .Include(repair => repair.Repairs)
                   .Include(part => part.Parts)
                   .Where(service => service.CarId == carId).ToListAsync();

                serviceFromDb.ForEach(service => service.Repairs
                .Select(async repair => await this.repairsService.HardDeleteAsync(repair.Id))
                .ToList()
                .ForEach(task => task.GetAwaiter().GetResult()));

                serviceFromDb.ForEach(service => service.Parts
                      .Select(async part => await this.partService.HardDeleteAsync(part.Id))
                      .ToList()
                      .Select(task => task.GetAwaiter().GetResult()));

                 serviceFromDb.ForEach(service => this.serviceRepository.HardDelete(service));
                return int.MaxValue;
                
            }
            catch (System.Exception ms)
            {

                throw new InvalidOperationException();
            }
        }
    }
}
