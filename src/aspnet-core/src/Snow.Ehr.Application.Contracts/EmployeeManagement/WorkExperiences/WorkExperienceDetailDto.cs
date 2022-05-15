using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.WorkExperiences
{
    /// <summary>
    /// 列表
    /// </summary>
    public class WorkExperienceDetailDto: EntityDto<System.Guid>
    {
        public string CompanyName { get; set; }
        public string Post { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime CreationTime { get; set; }
    }
}