﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GM.Domain;

namespace GM.DAL.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);

        /* Task<IEnumerable<TEntity>> GetAsync(
             string orderMember,
             OrderDirection orderDirection,
             int pageIndex = 1,
             int itemsPerPage = UIConstants.ItemsPerPage);*/

       // Task<TEntity> GetAsync(TKey key);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        IQueryable<TEntity> All();
    }
}
