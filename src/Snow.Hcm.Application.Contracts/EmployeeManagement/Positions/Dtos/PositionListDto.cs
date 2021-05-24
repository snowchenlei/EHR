using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.Positions.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class PositionListDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Department { get; set; }
    }
}