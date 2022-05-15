using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.Salaries
{
    /// <summary>
    /// 列表
    /// </summary>
    public class SalaryListDto: EntityDto<Guid>
    {
        public decimal BasicAmount { get; set; }
    }
}