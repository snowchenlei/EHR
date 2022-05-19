using AutoMapper;
using Snow.Ehr.EmployeeManagement.EducationExperiences;
using Snow.Ehr.EmployeeManagement.EmergencyContacts;
using Snow.Ehr.EmployeeManagement.Employees;
using Snow.Ehr.EmployeeManagement.Salaries;
using Snow.Ehr.EmployeeManagement.WorkExperiences;

namespace Snow.Ehr.EmployeeManagement
{
    /// <summary>
    /// Mapper映射配置
    /// </summary>
    public class EmployeeManagementApplicationAutoMapperProfile : Profile
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public EmployeeManagementApplicationAutoMapperProfile()
        {
            #region 员工

            CreateMap<Employee, GetEmployeeForEditorOutput>()
                .ForMember(entity => entity.Birthday,
                    opt => opt
                        .MapFrom(src =>
                            src.Birthday.ToString("yyyy-MM-dd")));
            CreateMap<Employee, EmployeeListDto>()
                .ForMember(entity => entity.Birthday,
                    opt => opt
                        .MapFrom(src =>
                            src.Birthday.ToString("yyyy-MM-dd")))
                .ForMember(entity => entity.JoinDate,
                    opt => opt
                        .MapFrom(src =>
                            src.JoinDate.ToString("yyyy-MM-dd")));
            CreateMap<Employee, EmployeeDetailDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();

            #endregion

            #region 紧急联络人

            CreateMap<EmergencyContact, GetEmergencyContactForEditorOutput>();
            CreateMap<EmergencyContact, EmergencyContactListDto>();
            CreateMap<EmergencyContact, EmergencyContactDetailDto>();
            CreateMap<EmergencyContactCreateDto, EmergencyContact>();
            CreateMap<EmergencyContactUpdateDto, EmergencyContact>();

            #endregion

            #region 工作经历

            CreateMap<WorkExperience, GetWorkExperienceForEditorOutput>();
            CreateMap<WorkExperience, WorkExperienceListDto>();
            CreateMap<WorkExperience, WorkExperienceDetailDto>();
            CreateMap<WorkExperienceCreateDto, WorkExperience>();
            CreateMap<WorkExperienceUpdateDto, WorkExperience>();

            #endregion
             #region 教育经历
            CreateMap<EducationExperience, GetEducationExperienceForEditorOutput>();
            CreateMap<EducationExperience, EducationExperienceListDto>();
            CreateMap<EducationExperience, EducationExperienceDetailDto>();
            CreateMap<EducationExperienceCreateDto, EducationExperience>();
            CreateMap<EducationExperienceUpdateDto, EducationExperience>();
            #endregion
             #region 工资
            CreateMap<Salary, GetSalaryForEditorOutput>();
            CreateMap<Salary, SalaryListDto>();
            CreateMap<Salary, SalaryDetailDto>();
            CreateMap<SalaryCreateDto, Salary>();
            CreateMap<SalaryUpdateDto, Salary>();
            #endregion
        }
    }
}