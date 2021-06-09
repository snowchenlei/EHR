using System;
using System.Collections.Generic;
using Snow.Hcm.EmployeeManagement.ContractAnnexes;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Snow.Hcm.EmployeeManagement.Contracts
{
    /// <summary>
    /// 合同
    /// </summary>
    public class Contract:Entity<Guid>,IHasCreationTime
    {
        public Contract()
        {
            ContractAnnexes = new List<ContractAnnex>();
        }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        
        public DateTime CreationTime { get; }

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
        
        /// <summary>
        /// 附件
        /// </summary>
        public ICollection<ContractAnnex> ContractAnnexes { get; set; }
    }
}