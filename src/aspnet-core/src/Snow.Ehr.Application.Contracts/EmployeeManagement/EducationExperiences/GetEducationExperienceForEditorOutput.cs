using System;
using Volo.Abp.Application.Dtos;

namespace Snow.Ehr.EmployeeManagement.EducationExperiences
{
    /// <summary>
    /// 修改输出
    /// </summary>
    public class GetEducationExperienceForEditorOutput : EntityDto<Guid>
    {
        public string SchoolName { get; set; }
        public string Specialty { get; set; }
        public Degree Degree { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}