namespace Snow.Hcm.EmployeeManagement.Positions.Dtos
{
    public class PositionCreateOrUpdateDtoBase
    {
        public string Name { get; set; }
        public System.Guid DepartmentId { get; set; }
    }
}