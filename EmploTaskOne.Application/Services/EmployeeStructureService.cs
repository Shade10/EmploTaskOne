using EmploTaskOne.Application.DTOs;
using EmploTaskOne.Domain.Interfaces;
using EmploTaskOne.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskOne.Application.Services
{
    public class EmployeeStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeService _employeeService;
        private List<EmployeeStructureDto> _employeeHierarchy;

        public EmployeeStructureService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeService = new EmployeeService();
        }

        public List<EmployeeStructureDto> FillEmployeesStructure()
        {
            var employees = _employeeRepository.GetAll();
            var hierarchy = _employeeService.BuildHierarchy(employees);

            _employeeHierarchy = hierarchy.Select(x => new EmployeeStructureDto
            {
                EmployeeId = x.EmployeeId,
                SuperiorId = x.SuperiorId,
                HierarchyRow = x.HierarchyRow
            }).ToList();

            return _employeeHierarchy;
        }

        public int? GetSuperiorRowOfEmployee(int employeeId, int superiorId)
        {
            if (_employeeHierarchy == null)
            {
                FillEmployeesStructure();
            }

            var record = _employeeHierarchy.FirstOrDefault(x =>
                x.EmployeeId == employeeId && x.SuperiorId == superiorId);

            return record?.HierarchyRow;
        }
    }
}
