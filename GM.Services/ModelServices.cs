using GM.DAL.Contracts;
using GM.Domain;
using GM.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GM.Services
{
    public class ModelServices : IModelServices
    {
        private readonly IModelRepositoty modelRepositoty;

        public ModelServices(IModelRepositoty modelRepositoty)
        {
            this.modelRepositoty = modelRepositoty;
        }
        public async Task<ICollection<string>> GetAllByMakeId(string id)
        {
            var result = await (this.modelRepositoty.GetAllModelsById(id).Select(model => model.Name).ToListAsync());

            return result;
        }
    }
}
