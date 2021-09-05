using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstractions
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();

        Student Get(int id);

        void Create(Student newStudent);

        Student CreateAndReturn(Student newStudent);

        void Update(Student updatedStudent);

        void Delete(Student oldStudent);
    }
}
