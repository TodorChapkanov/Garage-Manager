using GarageManager.DAL.Contracts;
using GarageManager.Data;
using GarageManager.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.Domain;
using GarageManager;

namespace GarageManager.DAL
{
    public abstract class RepositoryBase<TEntity, Tkey> : IRepository<TEntity>
        where TEntity : class
    {
        protected readonly GMDbContext dbContext;

        
        public RepositoryBase(GMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /*  public abstract Task<IEnumerable<TEntity>> GetAsync(
             string orderMember,
             OrderDirection orderDirection,
             int pageIndex = 1,
             int itemsPerPage = int.MaxValue);*/

        public async Task CreateAsync(TEntity entity)
        {
            await this.dbContext.AddAsync(entity);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            this.dbContext.Remove(entity);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetAsync(Tkey key)
        {
            var result = await this.dbContext.FindAsync<TEntity>(key);

            return result;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Update(entity);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> All()
        {
            var result = this.dbContext.Set<TEntity>();

            return result;
        }

      //protected async Task<IEnumerable<TEntity>> PaginateEntitiesAsync(
      //    IQueryable<TEntity> entities,
      //    string orderMember,
      //    OrderDirection orderDirection,
      //    int pageIndex,
      //    int itemsPerPage)
      //{
      //    switch (orderDirection)
      //    {
      //        case OrderDirection.Ascending:
      //        default:
      //            entities = entities.OrderByMember(orderMember);
      //
      //            break;
      //        case OrderDirection.Descending:
      //            entities = entities.OrderByMemberDescending(orderMember);
      //
      //            break;
      //    }
      //
      //    return await entities
      //        .Skip((pageIndex - 1) * itemsPerPage)
      //        .Take(itemsPerPage)
      //        .ToListAsync();
      //}

    }
}
