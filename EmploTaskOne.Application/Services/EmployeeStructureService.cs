using EmploTaskOne.Application.DTOs;
using EmploTaskOne.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskOne.Application.Services
{
    public class EmployeeStructureService
    {
        private List<EmployeeStructureDto> _employeeHierarchy;

        public List<EmployeeStructureDto> FillEmployeesStructure(List<Employee> employees)
        {
            _employeeHierarchy = new List<EmployeeStructureDto>();
            const int initialHierarchyRow = 1;

            foreach (var employee in employees)
            {
                BuildFullHierarchy(employee, employees, employee.SuperiorId, initialHierarchyRow);
            }

            return _employeeHierarchy;
        }

        private void BuildFullHierarchy(Employee employee, List<Employee> allEmployees, int? superiorId, int hierarchyRow)
        {
            if (superiorId == null)
                return;

            _employeeHierarchy.Add(new EmployeeStructureDto
            {
                EmployeeId = employee.Id,
                SuperiorId = superiorId.Value,
                HierarchyRow = hierarchyRow
            });

            var nextSuperior = allEmployees.FirstOrDefault(x => x.Id == superiorId.Value);
            if (nextSuperior != null)
            {
                BuildFullHierarchy(employee, allEmployees, nextSuperior.SuperiorId, hierarchyRow + 1);
            }
        }

        public int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
        {
            var record = _employeeHierarchy.FirstOrDefault(x => x.EmployeeId == employeeId && x.SuperiorId == superiorId);
            return record?.HierarchyRow;
        }
    }
}
