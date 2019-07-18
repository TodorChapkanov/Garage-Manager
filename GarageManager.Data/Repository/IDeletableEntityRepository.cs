﻿using GarageManager.Domain;
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

        Task<int> DeleteAsync(TEntity entity);

        Task<TEntity> GetAsync(string key);

        Task<int> Undelete(TEntity entity);

        Task UpdateAsync(TEntity entity);

        IQueryable<TEntity> All();
    }
}