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
        // todo make them async - but first do some research
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        Task /*void */Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}