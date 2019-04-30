//using Gemstone.Core.Abstracts;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.EntityFrameworkCore;
//using System.Linq;

//namespace Gemstone.Infrastructure
//{
//    public class Repository<T> : IRepository<T> where T : EntityBase
//    {
//        private readonly DbContext _dbContext;

//        public Repository(DbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public virtual T GetById(int id)
//        {
//            return _dbContext.Set<T>().Find(id);
//        }

//        public virtual IEnumerable<T> List()
//        {
//            return _dbContext.Set<T>().AsEnumerable();
//        }

//        public void Insert(T entity)
//        {
//            _dbContext.Set<T>().Add(entity);
//            _dbContext.SaveChanges();
//        }

//        public void Update(T entity)
//        {
//            _dbContext.Entry(entity).State = EntityState.Modified;
//            _dbContext.SaveChanges();
//        }

//        public void Delete(T entity)
//        {
//            _dbContext.Set<T>().Remove(entity);
//            _dbContext.SaveChanges();
//        }
//    }

//}
