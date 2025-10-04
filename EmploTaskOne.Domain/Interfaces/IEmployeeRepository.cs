using EmploTaskOne.Domain.Entities;
using System.Collections.Generic;

namespace EmploTaskOne.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
    }
}
