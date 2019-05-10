using Gemstone.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gemstone.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(TEntity entity);
    }
}