using GarageManager.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Data.Repository
{
    public class DeletableEntityRepository<TEntity> : IDeletableEntityRepository<TEntity>//: RepositoryBase<TEntity>, IDeletableEntityRepository<TEntity>
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

        /* public abstract Task<IEnumerable<TEntity>> GetAsync(
             string orderMember,
             OrderDirection orderDirection,
             int pageIndex = 1,
             int itemsPerPage = int.MaxValue);*/

        public async Task CreateAsync(TEntity entity)
        {
            await this.dbContext.AddAsync(entity);

            await this.dbContext.SaveChangesAsync();
        }

        // При триене на обект и повикване SavachangesAsync хвърля грешка "контекста е затворен"
        // За теста смени закоментираните редове с активните в момента
        // Метода се извиква от CarsServices => DeleteAsync
        public async/*void*/ Task<int> DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
          return await this.dbContext.SaveChangesAsync();
           // return this.dbContext.Update();
        }


        public async Task<TEntity> GetAsync(string key)
        {
            return await this.dbContext.FindAsync<TEntity>(key);
        }

        

        public async Task<int> Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
            this.dbContext.Update(entity);
           return await this.dbContext.SaveChangesAsync();
            
        }

        public async Task UpdateAsync(TEntity entity)
        {
            this.dbContext.Update(entity);

            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<TEntity> All()
        {
            return this.dbContext.Set<TEntity>().Where(x => !x.IsDeleted);
        }

      /*  protected async Task<IEnumerable<TEntity>> PaginateEntitiesAsync(
            IQueryable<TEntity> entities,
            string orderMember,
            OrderDirection orderDirection,
            int pageIndex,
            int itemsPerPage)
        {
            switch (orderDirection)
            {
                case OrderDirection.Ascending:
                default:
                    entities = entities.OrderByMember(orderMember);

                    break;
                case OrderDirection.Descending:
                    entities = entities.OrderByMemberDescending(orderMember);

                    break;
            }

            return await entities
                .Skip((pageIndex - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToListAsync();
        }*/
        /* public DeletableEntityRepository(GMDbContext context)
             : base(context)
         {
         }

         public override IQueryable<TEntity> All() => base.All().Where(x => !x.IsDeleted);

         public override IQueryable<TEntity> AllAsNoTracking() => base.AllAsNoTracking().Where(x => !x.IsDeleted);

         public IQueryable<TEntity> AllWithDeleted() => base.All().IgnoreQueryFilters();

         public IQueryable<TEntity> AllAsNoTrackingWithDeleted() => base.AllAsNoTracking().IgnoreQueryFilters();



         public void HardDelete(TEntity entity) => base.Delete(entity);

         public void Undelete(TEntity entity)
         {
             entity.IsDeleted = false;
             entity.DeletedOn = null;

             this.Update(entity);
         }

         public override void Delete(TEntity entity)
         {
             entity.IsDeleted = true;
             entity.DeletedOn = DateTime.UtcNow;
             base.DbSet.Update(entity);
             this.Update(entity);
         }*/
    }
}
