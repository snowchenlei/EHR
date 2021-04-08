using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Employees;
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
            Employees = new List<Employee>();
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
