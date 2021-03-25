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
            CreateMap<Employee, GetEmployeeForEditorOutput>();
            CreateMap<Employee, EmployeeListDto>()
                .ForMember(entity => entity.Gender,
                    opt => opt
                        .MapFrom(src =>
                            src.Gender.GetDescription()));
            CreateMap<Employee, EmployeeDetailDto>();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();
            #endregion
        }
    }
}