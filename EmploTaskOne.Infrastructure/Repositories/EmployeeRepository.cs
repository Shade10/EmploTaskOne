using EmploTaskOne.Domain.Entities;
using EmploTaskOne.Domain.Interfaces;
using EmploTaskOne.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskOne.Infrastructure.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmploTaskOneDbContext _context;

        public EmployeeRepository(EmploTaskOneDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.Select(e => new Employee
            {
                Id = e.Id,
                Name = e.Name,
                SuperiorId = e.SuperiorId
            }).ToList();
        }
    }
}
