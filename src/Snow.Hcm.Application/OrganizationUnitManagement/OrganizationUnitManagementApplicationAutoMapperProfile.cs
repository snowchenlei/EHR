using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public class OrganizationUnitManagementApplicationAutoMapperProfile: Profile
    {
        public OrganizationUnitManagementApplicationAutoMapperProfile()
        {
            CreateMap<OrganizationUnit, OrganizationUnitListDto>();
        }

    }
}
