namespace Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos
{
    public class WorkExperienceCreateOrUpdateDtoBase
    {
        public string CompanyName { get; set; }
        public string Post { get; set; }
        public string Description { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime CreationTime { get; set; }
    }
}