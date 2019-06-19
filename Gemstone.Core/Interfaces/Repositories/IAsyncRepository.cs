using Gemstone.Core.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> ExistsById(long id);
        Task<TEntity> GetByIdAsync(long id);
        Task<IReadOnlyCollection<TEntity>> ListAllAsync(); // todo collection vs list
        Task<TEntity> AddAsync(TEntity model);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity model);
    }
}