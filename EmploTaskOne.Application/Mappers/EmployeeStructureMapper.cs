using EmploTaskOne.Application.DTOs;
using EmploTaskOne.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace EmploTaskOne.Application.Mappers
{
    public static class EmployeeStructureMapper
    {
        public static List<EmployeeStructureDto> ToDtoList(List<EmployeeStructure> structures)
        {
            return structures.Select(x => new EmployeeStructureDto
            {
                EmployeeId = x.EmployeeId,
                SuperiorId = x.SuperiorId,
                HierarchyRow = x.HierarchyRow
            }).ToList();
        }
    }
}
