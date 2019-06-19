using Gemstone.Core.Abstracts;
using Gemstone.Core.Interfaces;
using Gemstone.Core.Interfaces.Repositories;
using Gemstone.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gemstone.Infrastructure
{
    public class EfRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly EfDbContext _dbContext;

        public EfRepository(EfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsById(long id) 
        {
            return await _dbContext.Set<TEntity>().AnyAsync(p => p.ID == id);
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IReadOnlyCollection<TEntity>> ListAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}