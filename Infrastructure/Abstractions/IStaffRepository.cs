using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstractions
{
    public interface IStaffRepository
    {
        IEnumerable<Staff> GetAll();

        Staff Get(int id);

        void Create(Staff newObject);

        Staff CreateAndReturn(Staff newObject);

        void Update(Staff updatedStaff);

        void Delete(Staff oldStaff);
    }
}
