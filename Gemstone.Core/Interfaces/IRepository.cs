using Gemstone.Core.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Core.Interfaces
{
    // todo create async generic repository
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> ExistsById(long id);
        Task<TEntity> ReadByIdAsync(long id);
        Task<IReadOnlyCollection<TEntity>> ReadAllAsync();
        Task CreateAsync(TEntity model);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity model);
    }

    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}