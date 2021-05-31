using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Snow.Hcm.OrganizationUnitManagement
{
    public class OrganizationUnitAppServices : HcmAppService, IOrganizationUnitAppServices
    {
        private readonly OrganizationUnitManager _organizationUnitManager;

        public OrganizationUnitAppServices(OrganizationUnitManager organizationUnitManager)
        {
            _organizationUnitManager = organizationUnitManager;
        }

        public virtual async Task<ListResultDto<OrganizationUnitListDto>> GetChildren(Guid? parentId)
        {
            List<OrganizationUnit> organizationUnits = await _organizationUnitManager.FindChildrenAsync(parentId);
            return new ListResultDto<OrganizationUnitListDto>(ObjectMapper.Map<List<OrganizationUnit>, List<OrganizationUnitListDto>>(organizationUnits));
        }
    }
}
