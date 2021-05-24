using Snow.Hcm.EmployeeManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Departments;
using Volo.Abp.Domain.Entities.Auditing;

namespace Snow.Hcm.EmployeeManagement.Positions
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class Position : CreationAuditedEntity<Guid>
    {
        public Position()
        {
            Employees = new List<Employee>();
        }
        
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        public Guid DepartmentId { get; set; }
        
        public Department Department { get; set; }
        
        public ICollection<Employee> Employees { get; set; }
    }
}
