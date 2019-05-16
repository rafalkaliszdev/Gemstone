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
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task Add(TEntity entity);
        Task Update(TEntity dbEntity, TEntity entity);
        Task Delete(TEntity entity);
    }
}