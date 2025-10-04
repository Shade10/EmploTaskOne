namespace EmploTaskOne.Application.DTOs
{
    public class EmployeeHierarchyStructureDto
    {
        public int EmployeeId { get; set; }
        public int SuperiorId { get; set; }
        public int HierarchyRow { get; set; }
    }
}
