using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Snow.Hcm.EmployeeManagement.EmergencyContacts
{
    /// <summary>
    /// 紧急联络人
    /// </summary>
    public class EmergencyContact:Entity<Guid>,IHasCreationTime
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 关系
        /// </summary>
        public string Relation { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>
        public Guid EmployeeId { get; set; }

        public DateTime CreationTime { get; }
    }
}
