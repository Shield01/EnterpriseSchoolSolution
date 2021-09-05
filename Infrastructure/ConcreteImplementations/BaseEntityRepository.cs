using Core.Models;
using Infrastructure.Abstractions;
using Infrastructure.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ConcreteImplementations
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        public BaseEntityRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        public void Create(T newObject)
        {
            newObject.DateCreated = DateTime.Now;

            _dbContext.Add(newObject);

            _dbContext.SaveChanges();
        }

        public T CreateAndReturn(T newObject)
        {
            _dbContext.Add(newObject);

            _dbContext.SaveChanges();

            return newObject;
        }

        public void Delete(T oldObject)
        {
            _dbContext.Remove(oldObject);

            _dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            var result = _dbContext.Set<T>().Find(id);

            return result;
        }

        public IEnumerable<T> GetAll()
        {
            var result = _dbContext.Set<T>();

            return result;
        }

        public void Update(T updatedObject)
        {
            updatedObject.DateModified = DateTime.Now;

            _dbContext.SaveChanges();
        }
    }
}
