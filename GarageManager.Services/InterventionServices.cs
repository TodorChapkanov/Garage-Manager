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
    }
}
