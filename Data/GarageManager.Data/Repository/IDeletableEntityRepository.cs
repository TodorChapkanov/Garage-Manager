using GarageManager.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Data.Repository
{
    public interface IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        // IQueryable<TEntity> AllWithDeleted();

         IQueryable<TEntity> AllAsNoTracking();

        Task<int> SavaChangesAsync();

        Task<int> CreateAsync(TEntity entity);

        Task<int> SoftDeleteAsync(TEntity entity);

        Task<int> HardDelete(params TEntity[] entity);


        void Undelete(TEntity entity);

        Task<int> Update(TEntity entity);

        Task<TEntity> GetEntityByKeyAsync(string key);

        IQueryable<TEntity> All();
    }
}
