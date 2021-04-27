using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Hcm.EmployeeManagement.Employees;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Snow.Hcm.EmployeeManagement.EducationExperiences
{
    /// <summary>
    /// 教育经历
    /// </summary>
    public class EducationExperience:Entity<Guid>,IHasCreationTime
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Specialty { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string EducationalBackground { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public DateTime CreationTime { get; }

        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
