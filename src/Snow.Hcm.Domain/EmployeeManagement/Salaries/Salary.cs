using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp.Domain.Entities;

namespace Snow.Hcm.EmployeeManagement.Salaries
{
    /// <summary>
    /// 工资
    /// </summary>
    public class Salary : Entity<Guid>
    {
        /// <summary>
        /// 基本工资
        /// </summary>
        public decimal BasicAmount { get; set; }

        /// <summary>
        /// 社保基数
        /// </summary>
        public decimal SocialInsuranceProportion { get; set; }

        /// <summary>
        /// 是否当前使用
        /// </summary>
        public bool IsCurrent { get; set; }

        public Guid EmployeeId { get; set; }
        
        /// <summary>
        /// 员工
        /// </summary>
        public Employee Employee { get; set; }
    }
}
