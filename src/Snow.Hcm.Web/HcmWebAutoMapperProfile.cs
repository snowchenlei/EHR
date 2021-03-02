using AutoMapper;
using Snow.Hcm.EmployeeManagement.Employees.Dtos;
using Snow.Hcm.Web.ViewModel.Employees;

namespace Snow.Hcm.Web
{
    public class HcmWebAutoMapperProfile : Profile
    {
        public HcmWebAutoMapperProfile()
        {            
            CreateMap<EmployeeCreateViewModel, EmployeeCreateDto>();
        }
    }
}
