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

       // IQueryable<TEntity> AllAsNoTrackingWithDeleted();


        Task CreateAsync(TEntity entity);

        Task<int> SoftDeleteAsync(TEntity entity);

        void HardDelete(TEntity entity);

        Task<TEntity> GetAsync(string key);

        Task<int> Undelete(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<TEntity> GetEntityByKeyAsync(string key);

        IQueryable<TEntity> All();
    }
}
