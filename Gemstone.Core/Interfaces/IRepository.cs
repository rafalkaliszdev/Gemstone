using Gemstone.Core.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> ExistsById(long id);
        Task<TEntity> ReadByIdAsync(long id);
        Task<IReadOnlyCollection<TEntity>> ReadAllAsync();
        Task CreateAsync(TEntity model);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity model);
    }
}