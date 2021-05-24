using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Hcm.EmployeeManagement.EducationExperiences.Dtos
{
    /// <summary>
    /// 列表
    /// </summary>
    public class EducationExperienceDetailDto: EntityDto<System.Guid>
    {
        public string SchoolName { get; set; }
        public string Specialty { get; set; }
        public Degree Degree { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}