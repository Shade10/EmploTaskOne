using EmploTaskOne.Application.DTOs;
using System.Collections.Generic;

namespace EmploTaskOne.Application.Interfaces
{
    public interface IEmployeeStructureService
    {
        List<EmployeeStructureDto> FillEmployeesStructure();
        int? GetSuperiorRowOfEmployee(int employeeId, int superiorId);
    }
}
