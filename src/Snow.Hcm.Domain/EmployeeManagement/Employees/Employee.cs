using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.DepartmentManagement.Departments;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.Salaries;
using Volo.Abp.Domain.Entities.Auditing;

namespace Snow.Hcm.EmployeeManagement.Employees
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee:FullAuditedEntity<Guid>
    {
        public Employee()
        {
            EmergencyContacts = new List<EmergencyContact>();
            Salaries = new List<Salary>();
        }

        /// <summary>
        /// 员工编号
        /// </summary>
        public string EmployeeNumber { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdCardNumber { get; set; }
        
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime ConfirmationDate { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 所在区域
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// 紧急联系人
        /// </summary>
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        public ICollection<Salary> Salaries { get; set; }
    }
}
