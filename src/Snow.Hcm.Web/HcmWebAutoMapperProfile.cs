using AutoMapper;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;
using Snow.Hcm.Web.ViewModel.Regions;
using Snow.RegionManagement.Admin.Regions;

namespace Snow.Hcm.Web
{
    public class HcmWebAutoMapperProfile : Profile
    {
        public HcmWebAutoMapperProfile()
        {            
            CreateMap<EmployeeCreateViewModel, EmployeeCreateDto>();
            CreateMap<GetRegionForEditOutput, RegionEditViewModel>();
        }
    }
}
