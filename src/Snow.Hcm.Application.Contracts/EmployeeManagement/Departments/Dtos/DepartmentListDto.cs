using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.Departments.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class DepartmentListDto: EntityDto<Guid>
    {
        public System.Guid? CreatorId { get; set; }
        public string Name { get; set; }
    }
}