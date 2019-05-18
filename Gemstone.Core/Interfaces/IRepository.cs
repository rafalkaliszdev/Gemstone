using Gemstone.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        // todo possible not good practice using async for GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(long id);
        Task AddAsync(TEntity model);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity model);
    }
}