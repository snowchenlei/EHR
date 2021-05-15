using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class WorkExperienceListDto: EntityDto<System.Guid>
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
        /// 工作时间
        /// </summary>
        public string WorkTime { get; set; }

        public System.DateTime CreationTime { get; set; }
    }
}