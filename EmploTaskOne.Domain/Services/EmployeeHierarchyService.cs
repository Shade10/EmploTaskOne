using EmploTaskOne.Domain.Entities;
using EmploTaskOne.Domain.Interfaces;
using EmploTaskOne.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskOne.Domain.Services
{
    public class EmployeeHierarchyService : IEmployeeHierarchyService
    {
        public List<EmployeeStructure> BuildHierarchy(List<Employee> employees)
        {
            var hierarchy = new List<EmployeeStructure>();
            const int initialHierarchyRow = 1;

            foreach (var employee in employees)
            {
                BuildFullHierarchy(employee, employees, employee.SuperiorId, initialHierarchyRow, hierarchy);
            }

            return hierarchy;
        }

        private void BuildFullHierarchy(Employee employee, List<Employee> allEmployees, int? superiorId, int hierarchyRow, List<EmployeeStructure> hierarchy)
        {
            if (superiorId == null)
            {
                return;
            }

            hierarchy.Add(new EmployeeStructure
            {
                EmployeeId = employee.Id,
                SuperiorId = superiorId.Value,
                HierarchyRow = hierarchyRow
            });

            var nextSuperior = allEmployees.FirstOrDefault(x => x.Id == superiorId.Value);
            if (nextSuperior != null)
            {
                BuildFullHierarchy(employee, allEmployees, nextSuperior.SuperiorId, hierarchyRow + 1, hierarchy);
            }
        }
    }
}
