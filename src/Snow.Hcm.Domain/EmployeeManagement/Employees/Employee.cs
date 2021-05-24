using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.Positions;
using Snow.Hcm.EmployeeManagement.Salaries;
using Snow.Hcm.EmployeeManagement.WorkExperiences;
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
            WorkExperiences = new List<WorkExperience>();
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
        /// 银行卡号
        /// </summary>
        public string BankCardNumber { get; set; }

        /// <summary>
        /// 婚姻状态
        /// </summary>
        public MaritalStatus MaritalStatus { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public PoliticalStatus PoliticalStatus { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 是否公历
        /// </summary>
        public bool IsGregorianCalendar { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// 转正日期
        /// </summary>
        public DateTime ConfirmationDate { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// 紧急联系人
        /// </summary>
        public ICollection<EmergencyContact> EmergencyContacts { get; set; }

        /// <summary>
        /// 工作经历
        /// </summary>
        public ICollection<WorkExperience> WorkExperiences { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        public ICollection<Salary> Salaries { get; set; }
    }
}
