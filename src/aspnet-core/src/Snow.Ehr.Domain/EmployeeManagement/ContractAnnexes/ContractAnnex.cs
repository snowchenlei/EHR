using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Ehr.EmployeeManagement.Contracts;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Snow.Ehr.EmployeeManagement.ContractAnnexes
{
    /// <summary>
    /// 合同附件
    /// </summary>
    public class ContractAnnex:Entity<Guid>,IHasCreationTime
    {
        public Guid FileId { get; set; }

        public Guid ContractId { get; set; }

        /// <summary>
        /// 合同
        /// </summary>
        public Contract Contract { get; set; }

        public DateTime CreationTime { get; }
    }
}
