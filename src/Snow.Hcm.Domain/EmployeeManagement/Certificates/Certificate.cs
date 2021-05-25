using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp.Domain.Entities;

namespace Snow.Hcm.EmployeeManagement.Certificates
{
    /// <summary>
    /// 证书
    /// </summary>
    public class Certificate:Entity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public Guid EmployeeId { get; set; }
            
        public Employee Employee { get; set; }
    }
}
