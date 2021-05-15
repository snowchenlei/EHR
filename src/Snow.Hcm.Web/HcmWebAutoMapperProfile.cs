using AutoMapper;
using Snow.Hcm.EmployeeManagement.Departments.Dtos;
using Snow.Hcm.EmployeeManagement.EmergencyContacts.Dtos;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.EmployeeManagement.WorkExperiences.Dtos;
using Snow.Hcm.Web.ViewModel.Departments;
using Snow.Hcm.Web.ViewModel.Employees;
using Snow.Hcm.Web.ViewModel.Employees.EmergencyContacts;
using Snow.Hcm.Web.ViewModel.Employees.WorkExperiences;
using Snow.Hcm.Web.ViewModel.Regions;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web
{
    public class HcmWebAutoMapperProfile : Profile
    {
        public HcmWebAutoMapperProfile()
        {
            #region Employee
            CreateMap<EmployeeCreateViewModel, EmployeeCreateDto>();
            CreateMap<EmployeeEditViewModel, EmployeeUpdateDto>();
            CreateMap<GetEmployeeForEditorOutput, EmployeeEditViewModel>();

            #region EmergencyContact
            CreateMap<EmergencyContactCreateViewModel, EmergencyContactCreateDto>();
            CreateMap<GetEmergencyContactForEditorOutput, EmergencyContactEditViewModel>();
            CreateMap<EmergencyContactEditViewModel, EmergencyContactUpdateDto>();
            #endregion

            #region WorkExperience

            CreateMap<WorkExperienceCreateViewModel, WorkExperienceCreateDto>();
            #endregion
            #endregion

            #region Department
            CreateMap<DepartmentCreateViewModel, DepartmentCreateDto>();
            CreateMap<DepartmentEditViewModel, DepartmentUpdateDto>();
            CreateMap<GetDepartmentForEditorOutput, DepartmentEditViewModel>(); 
            #endregion
        }
    }
}
