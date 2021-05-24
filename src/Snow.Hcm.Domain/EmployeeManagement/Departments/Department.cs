using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Positions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Snow.Hcm.EmployeeManagement.Departments
{
    /// <summary>
    /// 部门
    /// </summary>
    public class Department : CreationAuditedEntity<Guid>
    {
        public Department()
        {
            Positions = new List<Position>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        
        public ICollection<Position> Positions { get; set; }
    }
}
