using GM.DAL.Contracts;
using GM.Data;
using GM.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GM.Domain;

namespace GM.DAL
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
            return await this.dbContext.FindAsync<TEntity>(key);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Update(entity);

            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> All()
        {
            return this.dbContext.Set<TEntity>().AsNoTracking();
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
