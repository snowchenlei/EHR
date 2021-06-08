using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.Employees.Dtos
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetEmployeesInput: PagedAndSortedResultRequestDto
    {
        public GetEmployeesInput()
        {
            InServiceStatus = InServiceStatus.In;
        }   
        
        public string Name { get; set; }

        public InServiceStatus InServiceStatus { get; set; }
    }
}