using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstractions
{
    public interface IBaseEntityRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T newObject);

        T CreateAndReturn(T newObject);

        void Update(T updatedObject);

        void Delete(T oldObject);
    }
}
