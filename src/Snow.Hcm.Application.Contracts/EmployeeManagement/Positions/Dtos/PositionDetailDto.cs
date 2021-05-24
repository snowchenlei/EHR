using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.Positions.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class PositionDetailDto: EntityDto<System.Guid>
    {
        public string Name { get; set; }
    }
}