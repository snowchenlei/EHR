﻿using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.Contracts
{
    /// <summary>
    /// 列表
    /// </summary>
    public class ContractDetailDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string ContractNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}