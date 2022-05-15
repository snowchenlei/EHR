using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snow.Ehr.EmployeeManagement.Employees;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Snow.Ehr.EmployeeManagement.WorkExperiences
{
    /// <summary>
    /// 工作经历
    /// </summary>
    public class WorkExperience:Entity<Guid>,IHasCreationTime
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        public DateTime CreationTime { get; }
        
        public Guid EmployeeId { get; set; }
        
        public Employee Employee { get; set; }
        
    }
}
