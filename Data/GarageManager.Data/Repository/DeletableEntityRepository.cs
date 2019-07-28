using GarageManager.Domain;
using System;
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

        /* public abstract Task<IEnumerable<TEntity>> GetAsync(
             string orderMember,
             OrderDirection orderDirection,
             int pageIndex = 1,
             int itemsPerPage = int.MaxValue);*/

        public Task<int> SavaChangesAsync() => this.dbContext.SaveChangesAsync();

        public  Task CreateAsync(TEntity entity) =>   this.dbContext.AddAsync(entity);

        public void SoftDelete(TEntity entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
             this.dbContext.Update(entity);
            
        }

        public void HardDelete(params TEntity[] entity) => dbContext.RemoveRange(entity);

        public  Task<TEntity> GetEntityByKeyAsync(string key) =>   this.dbContext.FindAsync<TEntity>(key);

        public void Undelete(TEntity entity)
        {
            entity.IsDeleted = false;
            entity.DeletedOn = null;
             this.dbContext.Update(entity);
          
        }

        public void Update(TEntity entity) => this.dbContext.Update(entity);

        public IQueryable<TEntity> All() => this.dbContext.Set<TEntity>().Where(x => !x.IsDeleted);

     



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
