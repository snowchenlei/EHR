using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.WorkExperiences
{
    /// <summary>
    /// 列表
    /// </summary>
    public class WorkExperienceListDto: EntityDto<Guid>
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        public System.DateTime CreationTime { get; set; }
    }
}