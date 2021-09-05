using Core.Models;
using Infrastructure.Abstractions;
using Infrastructure.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ConcreteImplementations
{
    public class StudentRepository : BaseEntityRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
