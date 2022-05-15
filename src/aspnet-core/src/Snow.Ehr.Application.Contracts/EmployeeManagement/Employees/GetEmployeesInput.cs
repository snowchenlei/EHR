using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.Employees
{
    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetEmployeesInput: PagedAndSortedResultRequestDto
    {  
        
        public string Name { get; set; }

        public InServiceStatus InServiceStatus { get; set; }
    }
}