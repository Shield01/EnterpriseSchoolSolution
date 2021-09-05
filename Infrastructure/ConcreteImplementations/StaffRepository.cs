using Core.Models;
using Infrastructure.Abstractions;
using Infrastructure.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ConcreteImplementations
{
    public class StaffRepository : BaseEntityRepository<Staff>, IStaffRepository
    {
        public StaffRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
