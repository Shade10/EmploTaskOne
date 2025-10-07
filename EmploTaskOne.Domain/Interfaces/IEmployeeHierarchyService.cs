using EmploTaskOne.Domain.Entities;
using EmploTaskOne.Domain.ValueObjects;
using System.Collections.Generic;

namespace EmploTaskOne.Domain.Interfaces
{
    public interface IEmployeeHierarchyService
    {
        List<EmployeeStructure> BuildHierarchy(List<Employee> employees);
    }
}
