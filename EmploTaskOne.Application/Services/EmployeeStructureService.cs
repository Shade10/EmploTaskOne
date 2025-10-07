using EmploTaskOne.Application.DTOs;
using EmploTaskOne.Application.Interfaces;
using EmploTaskOne.Application.Mappers;
using EmploTaskOne.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskOne.Application.Services
{
    public class EmployeeStructureService : IEmployeeStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeHierarchyService _employeeHierarchyService;
        private List<EmployeeStructureDto> _employeeHierarchy;

        public EmployeeStructureService(IEmployeeRepository employeeRepository, IEmployeeHierarchyService employeeHierarchyService)
        {
            _employeeRepository = employeeRepository;
            _employeeHierarchyService = employeeHierarchyService;
        }

        public List<EmployeeStructureDto> FillEmployeesStructure()
        {
            var employees = _employeeRepository.GetAll();
            var hierarchy = _employeeHierarchyService.BuildHierarchy(employees);

            _employeeHierarchy = EmployeeStructureMapper.ToDtoList(hierarchy);

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
