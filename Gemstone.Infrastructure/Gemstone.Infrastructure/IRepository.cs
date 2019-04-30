using Gemstone.Core.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Gemstone.Infrastructure
{
    interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}