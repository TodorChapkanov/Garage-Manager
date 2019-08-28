using GarageManager.Domain;
using GarageManager.Services.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Data.Repository
{
    public class DeletableEntityRepository<TEntity> : IDeletableEntityRepository<TEntity>
        where TEntity : class, IDeletableEntity
    {
        protected readonly GMDbContext dbContext;

        public DeletableEntityRepository(GMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<TEntity> AllWithDeleted()
        {
            throw new NotImplementedException();
        }

       

        public Task<int> SavaChangesAsync() => this.dbContext.SaveChangesAsync();

        public async Task<int> CreateAsync(TEntity entity)
        {
           await this.dbContext.AddAsync(entity);
            return await this.SavaChangesAsync();
        }

        public async Task<int> SoftDeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
             this.dbContext.Update(entity);
            return await this.SavaChangesAsync();

        }

        public async Task<int> HardDelete(params TEntity[] entity)
        {
            dbContext.RemoveRange(entity);
            return await this.SavaChangesAsync();
        }

        public  Task<TEntity> GetEntityByKeyAsync(string key) =>   this.dbContext.FindAsync<TEntity>(key);

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
             this.dbContext.Update(entity);
        }

        public async Task<int> Update(TEntity entity)
        {
            this.dbContext.Update(entity);
            return await this.SavaChangesAsync();
        }

        public IQueryable<TEntity> All() => this.dbContext.Set<TEntity>().Where(x => !x.IsDeleted);

        public IQueryable<TEntity> AllAsNoTracking() => this.dbContext.Set<TEntity>().Where(x => !x.IsDeleted).AsNoTracking();
    }
}
