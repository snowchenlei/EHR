using Snow.Hcm.EmployeeManagement.EmergencyContacts;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using Snow.Hcm.EmployeeManagement.Departments;
using Snow.Hcm.EmployeeManagement.Departments.Dtos;
using Snow.Hcm.EmployeeManagement.Employees;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using AutoMapper;
using Masuit.Tools.Systems;

namespace Snow.Hcm.EmployeeManagement
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
                .ForMember(entity => entity.Gender,
                    opt => opt
                        .MapFrom(src =>
                            src.Gender.GetDescription()));
            CreateMap<Employee, EmployeeDetailDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            #endregion
             #region 部门
            CreateMap<Department, GetDepartmentForEditorOutput>();
            CreateMap<Department, DepartmentListDto>();
            CreateMap<Department, DepartmentDetailDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
            #endregion
             #region 紧急联络人
            CreateMap<EmergencyContact, GetEmergencyContactForEditorOutput>();
            CreateMap<EmergencyContact, EmergencyContactListDto>();
            CreateMap<EmergencyContact, EmergencyContactDetailDto>();
            CreateMap<EmergencyContactCreateDto, EmergencyContact>();
            CreateMap<EmergencyContactUpdateDto, EmergencyContact>();
            #endregion
        }
    }
}