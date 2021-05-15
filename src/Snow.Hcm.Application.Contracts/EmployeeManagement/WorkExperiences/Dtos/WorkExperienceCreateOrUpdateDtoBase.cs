using System;
namespace Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos
{
    public class WorkExperienceCreateOrUpdateDtoBase
    {
        public string CompanyName { get; set; }
        public string Post { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}